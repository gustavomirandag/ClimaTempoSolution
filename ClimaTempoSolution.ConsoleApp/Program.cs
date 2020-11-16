using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ClimaTempoSolution.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            string jsonContent = client.GetAsync("TYPE HERE YOUR CONNECTION STRING").Result.Content.ReadAsStringAsync().Result;
            var forecast = JsonConvert.DeserializeObject<Forecast>(jsonContent);

            Console.WriteLine("Country: " + forecast.country);
            Console.WriteLine("State: " + forecast.state);

            foreach(var day in forecast.data)
            {
                Console.WriteLine("-> Date: " + day.date_br);
                Console.WriteLine("   Temperature MIN: " + day.temperature.min + "ºC");
                Console.WriteLine("   Temperature MAX: " + day.temperature.max + "ºC");
                Console.WriteLine("   Description: " + day.text_icon.text.en);
                Console.WriteLine();
            }
        }
    }
}
