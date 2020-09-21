using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            List<string> list = new List<string>()
            {
                "109.234.37.221","109.234.37.222",
                "109.234.37.223"
            };
            foreach (var item in list)
            {
                for (int i = 0; i < 40; i++)
                {
                    var x = client.GetTime(item).GetAwaiter().GetResult();
                    Console.WriteLine(x.datetime.ToString());
                }
            }
            Console.WriteLine("OK");
            Console.ReadKey();
           
        }
    }
}
