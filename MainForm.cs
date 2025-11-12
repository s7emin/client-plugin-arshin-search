using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Globalization;
using ArshinSearch;
using Lers.Plugins;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Lers.Core;
using System.Threading; // Добавить в using, если ещё не добавлено
// using ArshinSearch.Properties; // больше не нужно
// Удалить using PuppeteerSharp; и PuppeteerSharp.Media;

namespace ArshinSearch
{
	public partial class MainForm : Form
	{
		string startpos = "0";
		IPluginHost host;
		private ArshinApi arshinApi = new ArshinApi();
		private Equipment[] equipmentList;
		// private TextBox textBoxMitNumber;
		// Удаляю поле ToolTip и его инициализацию
		// Добавляю поле для контекстного меню
		private ContextMenuStrip dateContextMenu;
		private int contextMenuRowIndex = -1;
		private CancellationTokenSource ownerSearchCts;

		public MainForm()
		{
			InitializeComponent();
			comboBox5.SelectedIndex = 0;
			// Включаем двойную буферизацию для MainView
			typeof(DataGridView).InvokeMember("DoubleBuffered",
				System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
				null, MainView, new object[] { true });

			// Фиксируем высоту строк для отображения двух строк текста
			MainView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			MainView.RowTemplate.Height = 36;


			MainView.CellMouseClick += MainView_CellMouseClick;
			MainView.ShowCellToolTips = true;
			MainView.CellToolTipTextNeeded -= MainView_CellToolTipTextNeeded;
			MainView.CellValueChanged += MainView_CellValueChanged;
			MainView.CurrentCellDirtyStateChanged += MainView_CurrentCellDirtyStateChanged;
			MainView.CellClick += MainView_CellClick;
			MainView.ColumnHeaderMouseClick += MainView_ColumnHeaderMouseClick;

			// Ограничить ширину столбца LersMeasurePoint
			//MainView.Columns["LersMeasurePoint"].Width = 120;
			//MainView.Columns["LersMeasurePoint"].MinimumWidth = 60;

			// Инициализация контекстного меню для даты поверки
			dateContextMenu = new ContextMenuStrip();
			var syncItem = new ToolStripMenuItem("⟳ Синхронизировать дату поверки");
			syncItem.Click += async (s, e) =>
			{
				if (contextMenuRowIndex >= 0)
					await UpdateCalibrationByRowIndex(contextMenuRowIndex);
			};
			dateContextMenu.Items.Add(syncItem);

			// Загружаем историю для всех ComboBox
			ComboHistoryManager.Load();
			LoadComboBoxHistory(comboBox1, "comboBox1");
			LoadComboBoxHistory(comboBox2, "comboBox2");
			LoadComboBoxHistory(comboBox3, "comboBox3");
			comboBox1.Leave += (s, e) => ComboBox_Leave(comboBox1, "comboBox1");
			comboBox2.Leave += (s, e) => ComboBox_Leave(comboBox2, "comboBox2");
			comboBox3.Leave += (s, e) => ComboBox_Leave(comboBox3, "comboBox3");
			// progressBar1.Paint += ProgressBar1_Paint; // Удалить строку подписки на Paint

			// Подписка на событие загрузки формы
			this.Load += MainForm_Load;

}



		internal void Initialize(IPluginHost host)
		{
			this.host = host;
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			try
			{
				var equipmentManager = host.Server.Equipment;
				equipmentList = await equipmentManager.GetListAsync();
				// equipmentList теперь содержит массив объектов Equipment
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при получении списка оборудования: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			if (ownerSearchCts != null)
			{
				// Уже идёт поиск — останавливаем
				ownerSearchCts.Cancel();
				return;
			}
			MainView.Columns["DgridOwner"].Visible = true;
			button1.Text = "Остановить поиск";
			ownerSearchCts = new CancellationTokenSource();
			var token = ownerSearchCts.Token;
			try
			{
				if (MainView.RowCount > 0)
				{
					for (int i = 0; i < MainView.RowCount; i++)
					{
						if (token.IsCancellationRequested) break;
						var row = MainView.Rows[i];
						// Проверяем, отмечена ли строка галочкой
						if (!(row.Cells[MainView.Columns["Check"].Index].Value is bool isChecked) || !isChecked)
							continue;
						if (row.Cells[MainView.Columns["DgridDocnumLink"].Index] == null) continue;
						string vri_id = row.Cells[MainView.Columns["DgridDocnumLink"].Index].Tag?.ToString();
						if (!string.IsNullOrEmpty(vri_id))
						{
							string miOwner = await arshinApi.GetMiOwnerAsync(vri_id);
							if (row.Cells[MainView.Columns["DgridOwner"].Index] != null)
								row.Cells[MainView.Columns["DgridOwner"].Index].Value = miOwner;
							await Task.Delay(200, token);
						}
					}
				}
			}
			catch (OperationCanceledException) { /* поиск остановлен */ }
			finally
			{
				ownerSearchCts.Dispose();
				ownerSearchCts = null;
				button1.Text = "Найти владельцев СИ";
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
		private void textBox1_TextChanged(object sender, EventArgs e) { }
		private void textBox2_TextChanged(object sender, EventArgs e) { }

		private SearchParams GetSearchParamsFromForm()
		{
			return new SearchParams
			{
				Number = textBox1.Text,
				Org = comboBox1.Text,
				Type = comboBox2.Text,
				MitNumber = comboBox3.Text, // Рег. номер типа СИ
				StartPos = startpos
				// Здесь можно добавить новые поля, если появятся
			};
		}

		private async void button2_Click(object sender, EventArgs e)
		{
			button2.Enabled = false;
			MainView.Rows.Clear();
			button1.Enabled = false;
			MainView.Columns["DgridOwner"].Visible = false;

			var searchParams = GetSearchParamsFromForm();
			// Проверка: хотя бы одно поле должно быть заполнено
			if (string.IsNullOrWhiteSpace(searchParams.Number)
				&& string.IsNullOrWhiteSpace(searchParams.Org)
				&& string.IsNullOrWhiteSpace(searchParams.Type)
				&& string.IsNullOrWhiteSpace(searchParams.MitNumber))
			{
				MessageBox.Show("Заполните хотя бы одно поле для поиска.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				button2.Enabled = true;
				return;
			}

			// Получаем лимит из comboBox5
			int limit = 100;
			if (comboBox5.SelectedItem != null && int.TryParse(comboBox5.SelectedItem.ToString(), out int parsedLimit))
				limit = parsedLimit;

			var allDocs = new List<VriDoc>();
			int numFound = 0;
			string error = null;
			int start = 0;
			const int rows = 100; // размер порции за 1 запрос всегда 100
			bool first = true;
			progressBar1.Minimum = 0;
			progressBar1.Value = 0;
			progressBar1.Maximum = limit;
			int maxApiRequests = 10;
			int apiRequestCount = 0;
			while (allDocs.Count < limit && apiRequestCount < maxApiRequests)
			{
				searchParams.StartPos = start.ToString();
				var (docs, found, err) = await arshinApi.SearchAsync(searchParams, rows);
				apiRequestCount++;
				if (first)
				{
					numFound = found;
					error = err;
					first = false;
					progressBar1.Maximum = Math.Min(limit, numFound > 0 ? numFound : limit);
					// Сразу выводим общее количество найденных записей
					this.Invoke((Action)(() => {
						textBox2.Text = $"0/{numFound}";
					}));
				}
				if (err != null)
				{
					MessageBox.Show("Ошибка при получении данных: " + err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					button2.Enabled = true;
					return;
				}
				if (docs.Count == 0) break;
				foreach (var doc in docs)
				{
					if (allDocs.Count >= limit) break;
					// --- Новый блок: вычисляем foundInner ДО добавления строки ---
					int rowIndex = -1;
					bool foundInner = false;
					Equipment foundEq = null;
					List<string> serialNumbers = new List<string>();
					if (!string.IsNullOrEmpty(doc.MiNumber))
					{
						serialNumbers = doc.MiNumber.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries).ToList();
					}
					List<Equipment> foundEquipments = new List<Equipment>();
					if (serialNumbers.Count > 0 && !string.IsNullOrEmpty(doc.MiMitnumber) && equipmentList != null)
					{
						foreach (var sn in serialNumbers)
						{
							var foundEquipment = equipmentList.FirstOrDefault(eq => eq.SerialNumber == sn &&
								(!string.IsNullOrEmpty(eq.StateRegisterNumber)
									? eq.StateRegisterNumber == doc.MiMitnumber
									: (eq.Model != null && eq.Model.StateRegisterNumbers != null && eq.Model.StateRegisterNumbers.Any(rn => rn.Number == doc.MiMitnumber))));
							if (foundEquipment != null)
							{
								foundEquipments.Add(foundEquipment);
							}
						}
						if (serialNumbers.Count == 2)
						{
							foundInner = foundEquipments.Count == 2;
							if (foundInner) foundEq = foundEquipments[0];
						}
						else
						{
							foundInner = foundEquipments.Count == 1;
							if (foundInner) foundEq = foundEquipments[0];
						}
					}
					// --- Фильтрация по checkBox1 ---
					if (checkBox1.Checked && !foundInner)
					{
						continue; // пропускаем строки без совпадения
					}
					allDocs.Add(doc);
					// --- Далее вся логика по поиску оборудования, подсветке, заполнению ячеек ---
					// Для корректной работы, если используются MainView.Rows[rowIndex], всё это должно быть внутри Invoke
					this.Invoke((Action)(() =>
					{
						rowIndex = MainView.Rows.Add(
							false,                // Check (чекбокс, по умолчанию не отмечен)
							doc.OrgTitle,         // DgridOrg
							doc.MiMitnumber,      // Dgridmimitnumber
							doc.MiMititle,        // Dgridminame
							doc.MiMitype,         // Drgridmitype
							doc.MiModification,   // DgridName
							doc.MiNumber,         // DgridNumber
							doc.MiDate,           // DgridDate
							doc.ValidDate,        // Dgriddatefor
							doc.Applicability,    // DgridAppc
							doc.MiDocnum,         // DgridDocnumLink
							"-",                  // DgridOwner
							"",                   // LersMeasurePoint
							""                    // DgridLersDate
						);
						// Устанавливаем Tag для ссылки
						MainView.Rows[rowIndex].Cells[MainView.Columns["DgridDocnumLink"].Index].Tag = doc.VriId;
					}));
					// --- Остальной код внутри Invoke ---
					this.Invoke((Action)(() =>
					{
						var serialCell = MainView.Rows[rowIndex].Cells[MainView.Columns["DgridNumber"].Index];
						var regnumCell = MainView.Rows[rowIndex].Cells[MainView.Columns["Dgridmimitnumber"].Index];
						string serialValue = serialCell.Value?.ToString();
						string regnumValue = regnumCell.Value?.ToString();
						var dateCell = MainView.Rows[rowIndex].Cells[MainView.Columns["DgridDate"].Index];
						string dateValue = dateCell.Value?.ToString();
						// --- Существующий код подсветки и заполнения ---
						if (foundInner)
						{
							serialCell.Style.BackColor = System.Drawing.Color.LightGreen;
							var mpCell = MainView.Rows[rowIndex].Cells[MainView.Columns["LersMeasurePoint"].Index];
							if (foundEq != null)
							{
								var points = foundEq.GetRelatedMeasurePoints();
								if (points != null && points.Length > 0)
								{
									mpCell.Value = string.Join(", ", points.Select(p => p.FullTitle));
								}
								else
								{
									mpCell.Value = string.Empty;
								}
							}
							if (!string.IsNullOrEmpty(dateValue) && foundEquipments.Count > 0 && foundInner)
							{
								DateTime parsedDate;
								bool parsed = DateTime.TryParseExact(dateValue, "dd.MM.yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
								if (parsed)
								{
									bool allMatch = true;
									bool anyNull = false;
									foreach (var eq in foundEquipments)
									{
										if (!eq.LastCalibrationDate.HasValue)
										{
											anyNull = true;
											allMatch = false;
										}
										else if (eq.LastCalibrationDate.Value.Date != parsedDate.Date)
										{
											allMatch = false;
										}
									}
									if (allMatch)
									{
										dateCell.Style.BackColor = System.Drawing.Color.LightGreen;
									}
									else if (!allMatch || anyNull)
									{
										dateCell.Style.BackColor = System.Drawing.Color.Orange;
										string icon = " ⟳";
										if (dateCell.Value != null && !dateCell.Value.ToString().Contains(icon))
										{
											dateCell.Value = dateCell.Value.ToString() + icon;
										}
									}
								}
							}
						}
						var lersDateCell = MainView.Rows[rowIndex].Cells[MainView.Columns["DgridLersDate"].Index];
						List<string> lersDates = new List<string>();
						if (serialNumbers.Count > 0 && !string.IsNullOrEmpty(regnumValue) && equipmentList != null)
						{
							foreach (var sn in serialNumbers)
							{
								var foundEquipment = equipmentList.FirstOrDefault(eq => eq.SerialNumber == sn &&
									(!string.IsNullOrEmpty(eq.StateRegisterNumber)
										? eq.StateRegisterNumber == regnumValue
										: (eq.Model != null && eq.Model.StateRegisterNumbers != null && eq.Model.StateRegisterNumbers.Any(rn => rn.Number == regnumValue))));
								if (foundEquipment != null)
								{
									string dateStr = foundEquipment.LastCalibrationDate.HasValue ? foundEquipment.LastCalibrationDate.Value.ToString("dd.MM.yy") : "нет данных";
									lersDates.Add(dateStr);
								}
							}
						}
						lersDateCell.Value = lersDates.Count > 0 ? string.Join("\n", lersDates) : "нет данных";
						// Обновление прогресса
						progressBar1.Value = Math.Min(allDocs.Count, progressBar1.Maximum);
						progressBar1.Refresh();
						textBox2.Text = $"{progressBar1.Value}/{numFound}";
					}));
					await Task.Yield(); // Позволяет UI отрисоваться
				}
				if (allDocs.Count >= numFound) break;
				start += rows;
				await Task.Delay(600); // Задержка между запросами
			}
			button2.Enabled = true;
			if (MainView.RowCount > 0) button1.Enabled = true;
			UpdateActionButtonsVisibility();
			progressBar1.Value = Math.Min(Math.Min(allDocs.Count, limit), progressBar1.Maximum);
			progressBar1.Value = progressBar1.Maximum;
		}

		private async void MainView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			// --- Открытие или сохранение PDF по клику на DgridDocnumLink ---
			if (e.RowIndex >= 0 && e.ColumnIndex == MainView.Columns["DgridDocnumLink"].Index)
			{
				var cell = MainView.Rows[e.RowIndex].Cells[MainView.Columns["DgridDocnumLink"].Index];
				var vriId = cell.Tag?.ToString();
				if (!string.IsNullOrEmpty(vriId))
				{
					string url = $"https://fgis.gost.ru/fundmetrology/cm/results/{vriId}";
					if (e.Button == MouseButtons.Left)
					{
						try
						{
							System.Diagnostics.Process.Start(url);
						}
						catch (Exception ex)
						{
							MessageBox.Show($"Не удалось открыть ссылку: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					else if (e.Button == MouseButtons.Right)
					{
						if (!string.IsNullOrEmpty(vriId))
						{
							try
							{
								string urlToCopy = $"https://fgis.gost.ru/fundmetrology/cm/results/{vriId}";
								Clipboard.SetText(urlToCopy);
								await ShowCopiedInCell(cell, vriId);
							}
							catch (Exception ex)
							{
								MessageBox.Show($"Ошибка копирования ссылки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
					}
				}
				return;
			}
            // --- Новый функционал: PUT по клику на оранжевую ячейку DgridDate ---
            // УДАЛЕНО: обработка синхронизации по левому клику на оранжевой ячейке даты поверки
            // --- Конец нового функционала ---
			// Контекстное меню для даты поверки
			if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex == MainView.Columns["DgridDate"].Index)
			{
				// Проверяем, найдено ли оборудование для этой строки
				var serialCell = MainView.Rows[e.RowIndex].Cells[MainView.Columns["DgridNumber"].Index];
				var regnumCell = MainView.Rows[e.RowIndex].Cells[MainView.Columns["Dgridmimitnumber"].Index];
				var serialValue = serialCell.Value?.ToString();
				var regnumValue = regnumCell.Value?.ToString();
				var serialNumbers = serialValue?.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
				var foundEquipments = new List<Lers.Core.Equipment>();
				if (serialNumbers.Length > 0 && !string.IsNullOrEmpty(regnumValue) && equipmentList != null)
				{
					foreach (var sn in serialNumbers)
					{
						var foundEquipment = equipmentList.FirstOrDefault(eq => eq.SerialNumber == sn &&
							(!string.IsNullOrEmpty(eq.StateRegisterNumber)
								? eq.StateRegisterNumber == regnumValue
								: (eq.Model != null && eq.Model.StateRegisterNumbers != null && eq.Model.StateRegisterNumbers.Any(rn => rn.Number == regnumValue))));
						if (foundEquipment != null)
						{
							foundEquipments.Add(foundEquipment);
						}
					}
				}
				if (foundEquipments.Count > 0)
				{
					contextMenuRowIndex = e.RowIndex;
					dateContextMenu.Show(MainView, MainView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location);
					return;
				}
			}
		}

		private async Task ShowCopiedInCell(DataGridViewCell cell, string vriId)
		{
			var originalValue = cell.Value;
			cell.Value = "Ссылка скопирована";
			cell.Style.ForeColor = System.Drawing.Color.Green;
			await Task.Delay(2000);
			cell.Value = originalValue;
			cell.Style.ForeColor = System.Drawing.Color.Black;
		}

		private async Task UpdateCalibrationByRowIndex(int rowIndex)
		{
			var cell = MainView.Rows[rowIndex].Cells[MainView.Columns["DgridDate"].Index];
			// Получаем arshinId из DgridDocnumLink (Tag)
			var arshinCell = MainView.Rows[rowIndex].Cells[MainView.Columns["DgridDocnumLink"].Index];
			var arshinId = arshinCell.Tag?.ToString();
			if (string.IsNullOrEmpty(arshinId))
			{
				MessageBox.Show("Не удалось определить arshinId.");
				return;
			}
			// Получаем equipmentId через Sensor (ищем по серийному номеру и рег. номеру)
			var serialCell = MainView.Rows[rowIndex].Cells[MainView.Columns["DgridNumber"].Index];
			var regnumCell = MainView.Rows[rowIndex].Cells[MainView.Columns["Dgridmimitnumber"].Index];
			var serialValue = serialCell.Value?.ToString();
			var regnumValue = regnumCell.Value?.ToString();
			var serialNumbers = serialValue?.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
			var foundEquipments = new List<Lers.Core.Equipment>();
			if (serialNumbers.Length > 0 && !string.IsNullOrEmpty(regnumValue) && equipmentList != null)
			{
				foreach (var sn in serialNumbers)
				{
					var foundEquipment = equipmentList.FirstOrDefault(eq => eq.SerialNumber == sn &&
						(!string.IsNullOrEmpty(eq.StateRegisterNumber)
							? eq.StateRegisterNumber == regnumValue
							: (eq.Model != null && eq.Model.StateRegisterNumbers != null && eq.Model.StateRegisterNumbers.Any(rn => rn.Number == regnumValue))));
					if (foundEquipment != null)
					{
						foundEquipments.Add(foundEquipment);
					}
				}
			}
			if (foundEquipments.Count == 0)
			{
				MessageBox.Show("Не удалось определить equipmentId.");
				return;
			}
			// Выполняем PUT-запрос для каждого найденного оборудования
			var restClient = host.Server.RestClient;
			var errors = new List<string>();
			bool allSuccess = true;
			foreach (var eq in foundEquipments)
			{
				string route = $"/api/v0.1/Core/Equipment/ArshinCalibration/{eq.Id}/{arshinId}";
				var response = await restClient.PutAsync(route, new { }, CancellationToken.None);
				if ((int)response.StatusCode != 200)
				{
					allSuccess = false;
					string result = await response.Content.ReadAsStringAsync();
					errors.Add($"{eq.SerialNumber}: {response.StatusCode} {result}");
				}
			}
			if (allSuccess)
			{
				// Перекрасить ячейку в зелёный и убрать иконку
				cell.Style.BackColor = System.Drawing.Color.LightGreen;
				string icon = " ⟳";
				if (cell.Value != null && cell.Value.ToString().Contains(icon))
				{
					cell.Value = cell.Value.ToString().Replace(icon, "");
				}
				MainView.Cursor = Cursors.Default;
				// Обновить значение в DgridLersDate
				var dateCell = MainView.Rows[rowIndex].Cells[MainView.Columns["DgridDate"].Index];
				var lersDateCell = MainView.Rows[rowIndex].Cells[MainView.Columns["DgridLersDate"].Index];
				string dateValue = dateCell.Value?.ToString() ?? "";
				int iconIndex = dateValue.IndexOf(" ⟳");
				if (iconIndex >= 0)
					dateValue = dateValue.Substring(0, iconIndex);
				dateValue = dateValue.Trim();
				lersDateCell.Value = dateValue;
			}
			if (errors.Count > 0)
			{
				MessageBox.Show("Ошибки при обновлении:\n" + string.Join("\n", errors), "Результат ArshinCalibration");
			}
		}

		private void MainView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == MainView.Columns["Check"].Index)
			{
				UpdateActionButtonsVisibility();
			}
		}
		private void MainView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (MainView.CurrentCell != null && MainView.CurrentCell.ColumnIndex == MainView.Columns["Check"].Index)
			{
				MainView.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}
		private void UpdateActionButtonsVisibility()
		{
			bool anyChecked = false;
			foreach (DataGridViewRow row in MainView.Rows)
			{
				if (row.Cells[MainView.Columns["Check"].Index].Value is bool isChecked && isChecked)
				{
					anyChecked = true;
					break;
				}
			}
			button1.Visible = anyChecked;
		}

		private class ComboHistoryItem
		{
			public string value { get; set; }
			public DateTime date { get; set; }
		}

		private class ComboHistoryManager
		{
			private static string ConfigDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LERS", "Client", "Config");
			private static string ConfigFile => Path.Combine(ConfigDir, "ArshinSearch.json");
			public static Dictionary<string, List<ComboHistoryItem>> Data = new Dictionary<string, List<ComboHistoryItem>>();

			public static void Load()
			{
				if (!Directory.Exists(ConfigDir))
					Directory.CreateDirectory(ConfigDir);
				if (File.Exists(ConfigFile))
				{
					try
					{
						var json = File.ReadAllText(ConfigFile);
						Data = JsonConvert.DeserializeObject<Dictionary<string, List<ComboHistoryItem>>>(json) ?? new Dictionary<string, List<ComboHistoryItem>>();
					}
					catch { Data = new Dictionary<string, List<ComboHistoryItem>>(); }
				}
				else
				{
					Data = new Dictionary<string, List<ComboHistoryItem>>();
				}
			}

			public static void Save()
			{
				try
				{
					var json = JsonConvert.SerializeObject(Data, Formatting.Indented);
					File.WriteAllText(ConfigFile, json);
				}
				catch { /* ignore errors */ }
			}

			public static List<ComboHistoryItem> GetHistory(string key)
			{
				if (Data.ContainsKey(key))
					return Data[key].OrderByDescending(i => i.date).Take(8).ToList();
				return new List<ComboHistoryItem>();
			}

			public static void AddOrUpdate(string key, string value)
			{
				if (string.IsNullOrWhiteSpace(value)) return;
				if (!Data.ContainsKey(key))
					Data[key] = new List<ComboHistoryItem>();
				// Удаляем старое значение, если оно есть
				Data[key] = Data[key].Where(i => i.value != value).ToList();
				// Добавляем новое/обновлённое
				Data[key].Add(new ComboHistoryItem { value = value, date = DateTime.Now });
				// Оставляем только 8 самых свежих
				Data[key] = Data[key].OrderByDescending(i => i.date).Take(8).ToList();
				Save();
			}
		}

		private void LoadComboBoxHistory(ComboBox comboBox, string key)
		{
			comboBox.Items.Clear();
			var items = ComboHistoryManager.GetHistory(key);
			foreach (var item in items)
			{
				comboBox.Items.Add(item.value);
			}
		}

		private void ComboBox_Leave(ComboBox comboBox, string key)
		{
			string value = comboBox.Text;
			if (!string.IsNullOrWhiteSpace(value))
			{
				ComboHistoryManager.AddOrUpdate(key, value);
				LoadComboBoxHistory(comboBox, key);
			}
		}

		private void MainView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
		{
			// Удаляю все упоминания ToolTip, lersDateToolTip и связанные с ними строки
		}

		private void MainView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Удалено: ручная инверсия чекбокса по клику
		}

		private void MainView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex == MainView.Columns["Check"].Index)
			{
				bool anyUnchecked = MainView.Rows.Cast<DataGridViewRow>()
					.Any(row => !(row.Cells[e.ColumnIndex].Value is bool b) || !b);
				foreach (DataGridViewRow row in MainView.Rows)
				{
					row.Cells[e.ColumnIndex].Value = anyUnchecked;
				}
				UpdateActionButtonsVisibility();
			}
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
