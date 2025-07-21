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
// using ArshinSearch.Properties; // больше не нужно

namespace ArshinSearch
{
	public partial class MainForm : Form
	{
		string startpos = "0";
		IPluginHost host;
		private ArshinApi arshinApi = new ArshinApi();
		private Equipment[] equipmentList;
		// private TextBox textBoxMitNumber;

		public MainForm()
		{
			InitializeComponent();
			// Включаем двойную буферизацию для MainView
			typeof(DataGridView).InvokeMember("DoubleBuffered",
				System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
				null, MainView, new object[] { true });

			// Фиксируем высоту строк для отображения двух строк текста
			MainView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			MainView.RowTemplate.Height = 36;

			// Инициализация textBoxMitNumber для предотвращения ошибки компиляции
			// textBoxMitNumber = new TextBox();
			MainView.CellMouseClick += MainView_CellMouseClick;

			// Ограничить ширину столбца LersMeasurePoint
			MainView.Columns["LersMeasurePoint"].Width = 120;
			MainView.Columns["LersMeasurePoint"].MinimumWidth = 60;

			// Загружаем историю для всех ComboBox
			ComboHistoryManager.Load();
			LoadComboBoxHistory(comboBox1, "comboBox1");
			LoadComboBoxHistory(comboBox2, "comboBox2");
			LoadComboBoxHistory(comboBox3, "comboBox3");
			comboBox1.Leave += (s, e) => ComboBox_Leave(comboBox1, "comboBox1");
			comboBox2.Leave += (s, e) => ComboBox_Leave(comboBox2, "comboBox2");
			comboBox3.Leave += (s, e) => ComboBox_Leave(comboBox3, "comboBox3");

			// Подписка на событие загрузки формы
			this.Load += MainForm_Load;
		}

		internal void Initialize(IPluginHost host)
		{
			this.host = host;
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			if (host == null)
				return;
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

		private void MainView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == MainView.Columns["DgridDocnumLink"].Index && MainView.SelectedCells.Count > 0)
			{
				try
				{
					var cellValue = MainView.SelectedCells[0].Tag?.ToString();
					if (!string.IsNullOrEmpty(cellValue))
					{
						System.Diagnostics.Process.Start("https://fgis.gost.ru/fundmetrology/cm/results/" + cellValue);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Не удалось открыть ссылку: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			if (MainView.RowCount > 0)
			{
				for (int i = 0; i < MainView.RowCount; i++)
				{
					var row = MainView.Rows[i];
					if (row.Cells[MainView.Columns["DgridDocnumLink"].Index] == null) continue;
					string vri_id = row.Cells[MainView.Columns["DgridDocnumLink"].Index].Tag?.ToString();
					if (!string.IsNullOrEmpty(vri_id))
					{
						string miOwner = await arshinApi.GetMiOwnerAsync(vri_id);
						if (row.Cells[MainView.Columns["DgridOwner"].Index] != null)
							row.Cells[MainView.Columns["DgridOwner"].Index].Value = miOwner;
						await Task.Delay(200);
					}
				}
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
			textBox2.Text = "";
			button1.Enabled = false;

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

			var (docs, numFound, error) = await arshinApi.SearchAsync(searchParams);
			if (error != null)
			{
				MessageBox.Show("Ошибка при получении данных: " + error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				button2.Enabled = true;
				return;
			}
			textBox2.Text = numFound.ToString();
			foreach (var doc in docs)
			{
				int rowIndex = MainView.Rows.Add(doc.OrgTitle, doc.MiMitnumber, doc.MiMititle, doc.MiMitype, doc.MiModification, doc.MiNumber, doc.MiDate, doc.ValidDate, doc.Applicability, doc.MiDocnum, "-");
				// Устанавливаем Tag для ссылки
				MainView.Rows[rowIndex].Cells[MainView.Columns["DgridDocnumLink"].Index].Tag = doc.VriId;
				// Проверка заводского номера и регистрационного номера типа СИ по именам столбцов
				var serialCell = MainView.Rows[rowIndex].Cells[MainView.Columns["DgridNumber"].Index];
				var regnumCell = MainView.Rows[rowIndex].Cells[MainView.Columns["Dgridmimitnumber"].Index];
				string serialValue = serialCell.Value?.ToString();
				string regnumValue = regnumCell.Value?.ToString();
				var dateCell = MainView.Rows[rowIndex].Cells[MainView.Columns["DgridDate"].Index];
				string dateValue = dateCell.Value?.ToString();
				bool found = false;
				Equipment foundEq = null;
				// --- Новая логика для двух номеров ---
				List<string> serialNumbers = new List<string>();
				if (!string.IsNullOrEmpty(serialValue))
				{
					serialNumbers = serialValue.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries).ToList();
				}
				// Если два номера, оба должны быть найдены
				List<Equipment> foundEquipments = new List<Equipment>();
				if (serialNumbers.Count > 0 && !string.IsNullOrEmpty(regnumValue) && equipmentList != null)
				{
					foreach (var sn in serialNumbers)
					{
						var foundEquipment = equipmentList.FirstOrDefault(eq => eq.SerialNumber == sn &&
							(
								!string.IsNullOrEmpty(eq.StateRegisterNumber)
									? eq.StateRegisterNumber == regnumValue
									: (eq.Model != null && eq.Model.StateRegisterNumbers != null && eq.Model.StateRegisterNumbers.Any(rn => rn.Number == regnumValue))
							)
						);
						if (foundEquipment != null)
						{
							foundEquipments.Add(foundEquipment);
						}
					}
					if (serialNumbers.Count == 2)
					{
						found = foundEquipments.Count == 2;
						if (found) foundEq = foundEquipments[0]; // Для дальнейшей логики (точка измерения и дата)
					}
					else // один номер
					{
						found = foundEquipments.Count == 1;
						if (found) foundEq = foundEquipments[0];
					}
				}
				if (found)
				{
					serialCell.Style.BackColor = System.Drawing.Color.LightGreen;
					// Заполнение столбца LersMeasurePoint
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
					// --- Новая логика сравнения даты поверки для двух номеров ---
					if (!string.IsNullOrEmpty(dateValue) && foundEquipments.Count > 0 && found)
					{
						DateTime parsedDate;
						bool parsed = DateTime.TryParseExact(dateValue, "dd.MM.yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
						if (parsed)
						{
							bool allMatch = true;
							foreach (var eq in foundEquipments)
							{
								if (!eq.LastCalibrationDate.HasValue || eq.LastCalibrationDate.Value.Date != parsedDate.Date)
								{
									allMatch = false;
									break;
								}
							}
							if (allMatch)
							{
								dateCell.Style.BackColor = System.Drawing.Color.LightGreen;
							}
							else
							{
								dateCell.Style.BackColor = System.Drawing.Color.Orange;
							}
						}
					}
				}
			}
			button2.Enabled = true;
			if (MainView.RowCount > 0) button1.Enabled = true;
		}

		private async void MainView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex == MainView.Columns["DgridDocnumLink"].Index)
			{
				var cell = MainView.Rows[e.RowIndex].Cells[MainView.Columns["DgridDocnumLink"].Index];
				var vriId = cell.Tag?.ToString();
				if (!string.IsNullOrEmpty(vriId))
				{
					string url = $"https://fgis.gost.ru/fundmetrology/cm/results/{vriId}";
					Clipboard.SetText(url);
					await ShowCopiedInCell(cell, vriId);
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
	}
}
