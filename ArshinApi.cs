using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArshinSearch
{
    public class VriDoc
    {
        public string OrgTitle { get; set; }
        public string MiMitnumber { get; set; }
        public string MiMititle { get; set; }
        public string MiMitype { get; set; }
        public string MiModification { get; set; }
        public string MiNumber { get; set; }
        public string MiDate { get; set; }
        public string ValidDate { get; set; }
        public bool Applicability { get; set; }
        public string MiDocnum { get; set; }
        public string VriId { get; set; }
    }

    public class SearchParams
    {
        public string Number { get; set; }
        public string Org { get; set; }
        public string Type { get; set; }
        public string MitNumber { get; set; } // Рег. номер типа СИ
        // Здесь можно добавить новые поля для поиска
        public string StartPos { get; set; } = "0";
    }

    public class ArshinApi
    {
        private readonly HttpClient client;
        private const string BaseRequest = "https://fgis.gost.ru/fundmetrology/cm/xcdb/vri/select?";
        private const string VriInfoUrl = "https://fgis.gost.ru/fundmetrology/cm/iaux/vri/";

        private const string FieldList =
            "vri_id,org_title,mi.mitnumber,mi.mititle,mi.mitype,mi.modification,mi.number," +
            "verification_date,valid_date,applicability,result_docnum";
        private const string SortOrder = "verification_date desc,org_title asc";
        private const int DefaultRows = 100;

        private const int MaxAttempts = 2;
        private const int RetryDelayMs = 1500;

        public ArshinApi()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36");
        }

        public async Task<(List<VriDoc> docs, int numFound, string error)> SearchAsync(SearchParams searchParams, int rows = DefaultRows)
        {
            var docs = new List<VriDoc>();
            int numFound = 0;
            string error = null;

            string url = BuildSearchUrl(searchParams, rows);

            try
            {
                string responseBody = await GetWithRetryAsync(url).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(responseBody);
                numFound = (int?)jsonResponse.SelectToken("response.numFound") ?? 0;
                var docsArray = (JArray)jsonResponse["response"]["docs"];
                foreach (var doc in docsArray)
                {
                    docs.Add(ParseVriDoc(doc));
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return (docs, numFound, error);
        }

        public async Task<string> GetMiOwnerAsync(string vriId)
        {
            try
            {
                // vriId подставляется в путь, а не в query-строку, поэтому экранируем отдельно
                string url = VriInfoUrl + Uri.EscapeDataString(vriId ?? string.Empty);
                string responseBody = await GetWithRetryAsync(url).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(responseBody);
                return (string)jsonResponse.SelectToken("result.vriInfo.miOwner") ?? "";
            }
            catch
            {
                return "Ошибка";
            }
        }

        private static string BuildSearchUrl(SearchParams searchParams, int rows)
        {
            var queryParts = new List<string>();

            AddFilter(queryParts, "mi.number", searchParams.Number);
            AddFilter(queryParts, "org_title", searchParams.Org, wildcard: true);
            AddFilter(queryParts, "mi.mitype", searchParams.Type, wildcard: true);
            AddFilter(queryParts, "mi.mitnumber", searchParams.MitNumber);

            queryParts.Add("q=" + Uri.EscapeDataString("*"));
            queryParts.Add("fl=" + Uri.EscapeDataString(FieldList));
            queryParts.Add("sort=" + Uri.EscapeDataString(SortOrder));
            queryParts.Add("rows=" + rows.ToString(CultureInfo.InvariantCulture));
            queryParts.Add("start=" + Uri.EscapeDataString(searchParams.StartPos ?? "0"));

            return BaseRequest + string.Join("&", queryParts);
        }
        private static void AddFilter(List<string> queryParts, string field, string value, bool wildcard = false)
        {
            if (string.IsNullOrEmpty(value))
                return;

            string rawFilter = wildcard ? $"{field}:*{value}*" : $"{field}:{value}";
            queryParts.Add("fq=" + Uri.EscapeDataString(rawFilter));
        }

        private static VriDoc ParseVriDoc(JToken doc)
        {
            string miDate = SafeDate(doc.SelectToken("$.['verification_date']"));
            bool applicability = (bool?)doc.SelectToken("$.['applicability']") ?? false;
            string validDate = applicability ? SafeDate(doc.SelectToken("$.['valid_date']")) : "-";

            return new VriDoc
            {
                OrgTitle = (string)doc.SelectToken("$.['org_title']") ?? "",
                MiMitnumber = (string)doc.SelectToken("$.['mi.mitnumber']") ?? "",
                MiMititle = (string)doc.SelectToken("$.['mi.mititle']") ?? "",
                MiMitype = (string)doc.SelectToken("$.['mi.mitype']") ?? "",
                MiModification = (string)doc.SelectToken("$.['mi.modification']") ?? "",
                MiNumber = (string)doc.SelectToken("$.['mi.number']") ?? "",
                MiDate = miDate,
                ValidDate = validDate,
                Applicability = applicability,
                MiDocnum = (string)doc.SelectToken("$.['result_docnum']") ?? "",
                VriId = (string)doc.SelectToken("$.['vri_id']") ?? ""
            };
        }

        private static string SafeDate(JToken token)
        {
            string dateStr = (string)token;
            if (string.IsNullOrEmpty(dateStr) || dateStr.Length < 10)
                return "";
            dateStr = dateStr.Substring(0, 10);
            if (DateTime.TryParseExact(dateStr, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                return parsedDate.ToString("dd.MM.yy");
            return dateStr;
        }

        private async Task<string> GetWithRetryAsync(string url)
        {
            for (int attempt = 1; attempt <= MaxAttempts; attempt++)
            {
                using (var response = await client.GetAsync(url).ConfigureAwait(false))
                {
                    if ((int)response.StatusCode != 429)
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    }
                    if (attempt == MaxAttempts)
                        throw new HttpRequestException($"Сервер вернул TooManyRequests (429) {MaxAttempts} раза подряд");
                }
                await Task.Delay(RetryDelayMs).ConfigureAwait(false);
            }
            throw new HttpRequestException("Не удалось выполнить запрос");
        }
    }
}