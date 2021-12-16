using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OxyPlotTest.Classes
{
    public class WebServiceClass
    {

        HttpClient client = new HttpClient();

        public async Task<ObservableCollection<ReportsClass>> Reports(int parentid, DateTime startDate, DateTime endDate)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("parentid", parentid.ToString()),
                new KeyValuePair<string, string>("startDate", startDate.ToString("yyyy-MM-dd H:mm:ss")),
                new KeyValuePair<string, string>("endDate", endDate.ToString("yyyy-MM-dd"))
            });

            var response = await client.PostAsync(string.Format("https://jamessuske.com/grounded_api/index.php?action=reports"), content);

            var responseString = await response.Content.ReadAsStringAsync();

            ObservableCollection<ReportsClass> items = JsonConvert.DeserializeObject<ObservableCollection<ReportsClass>>(responseString);

            return items;

        }
    }
}
