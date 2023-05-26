using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GUSDataViewer.Model;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace GUSDataViewer.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<Area> Areas { get; set; } = new ObservableCollection<Area>();

        public Area SelectedArea { get; set; }
        public async Task LoadAsync()
        {

            HttpClient client = new HttpClient();


            //For this example putting Uri directly into code was sufficient but a better approach wold be placing it in configuration file
            client.BaseAddress = new Uri("https://api-dbw.stat.gov.pl");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("/api/1.1.0/area/area-area");
            if (response.IsSuccessStatusCode)
            {
                var allAreas = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<Area>>(allAreas);

                foreach (var area in deserialized)
                {
                    Areas.Add(area);
                }
            }
        }
    }
}
