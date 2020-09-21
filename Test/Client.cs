using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Buffer;

namespace Example
{
    class Client
    {
        public async Task<TimeType> GetTime(string ip)
        {
            var resz =  buffer.Check(ip);
            if (resz != null) return resz;
            var res = await client.GetAsync(string.Format("http://worldtimeapi.org/api/ip/{0}.json",ip));
            string html = await res.Content.ReadAsStringAsync();
            Console.WriteLine("SEND");
            var time =  JsonConvert.DeserializeObject<TimeType>(html);
            buffer.Add(time, ip);
            return time;
        }
        HttpClient client;
        CollectionBuffer<TimeType> buffer;
        public Client()
        {
            this.client = new HttpClient();
            this.buffer = new CollectionBuffer<TimeType>(30);
        }
    }
}
