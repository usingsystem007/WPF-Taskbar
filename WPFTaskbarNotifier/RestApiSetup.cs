using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPFTaskbarNotifier
{
    public enum HttpVerbs
    {
        Get,
        Post,
        Put,
        Delete,
    }

    public class RestApiSetup
    {
        public string Url { private get; set; }
        public JArray Queue { get; set; }

        public async Task<IEnumerable<NotificationItem>> LoadData(string url)
        {
            var list = new List<NotificationItem>();
            var task = await LoadDataAsync(url);

            foreach (var value in Queue)
            {
                var result = JObject.Parse(value.ToString());
                var model = new NotificationItem()
                {
                    Nama = result["first_name"].ToString() as string,
                    Company = result["company"].ToString() as string
                };
                list.Add(model);
            }
            return list;
        }

        public async Task<IEnumerable<NotificationItem>> CountData(string url)
        {
            var list = new List<NotificationItem>();
            var task = await CountDataAsync(url);

            foreach (var value in Queue)
            {
                var result = JObject.Parse(value.ToString());
                var model = new NotificationItem()
                {
                    Count = result["count"].ToString() as string
                };
                list.Add(model);
            }
            return list;
        }

        public bool SenderData(NotificationItem model, HttpVerbs verbs)
        {
            var result = false;
            var json = JsonConvert.SerializeObject(model);
            var task = Task.Run(async () => await DataSenderAsync(json, verbs));
            if (task.Result)
            {
                result = true;
            }
            return result;
        }

        private async Task<bool> DataSenderAsync(string jsonbody, HttpVerbs verb)
        {
            var state = false;
            try
            {
                Task<HttpResponseMessage> client = null;
                var content = new StringContent(jsonbody, Encoding.UTF8, "application/json");
                switch (verb)
                {
                    case HttpVerbs.Post:
                        client = new HttpClient().PostAsync(Url, content);
                        break;
                    case HttpVerbs.Put:
                        client = new HttpClient().PutAsync(Url, content);
                        break;
                    case HttpVerbs.Delete:
                        client = new HttpClient().DeleteAsync(Url);
                        break;
                }
                var response = await client;
                var api = await response.Content.ReadAsStringAsync();
                return true;
            }
            catch { }
            return state;
        }

        public async Task<IEnumerable<NotificationItem>> LoadDataAsync(string url)
        {
            var list = new List<NotificationItem>();
            using (var client = new HttpClient())
            {
                try
                {
                    var api = await client.GetStringAsync(url);
                    var json = JArray.Parse(api);
                    Queue = json;
                    foreach (var value in json)
                    {
                        var result = JObject.Parse(value.ToString());
                        var model = new NotificationItem()
                        {
                            Nama = result["first_name"].ToString() as string,
                            Company = result["company"].ToString() as string
                        };
                        list.Add(model);
                    }
                }
                catch { }
            }
            return list;
        }

        public async Task<IEnumerable<NotificationItem>> CountDataAsync(string url)
        {
            var list = new List<NotificationItem>();
            using (var client = new HttpClient())
            {
                try
                {
                    var api = await client.GetStringAsync(url);
                    var json = JArray.Parse(api);
                    Queue = json;
                    foreach (var value in json)
                    {
                        var result = JObject.Parse(value.ToString());
                        var model = new NotificationItem()
                        {
                            Count = result["Jumlah"].ToString() as string
                        };
                        list.Add(model);
                    }
                }
                catch { }
            }
            return list;
        }
    }
}
