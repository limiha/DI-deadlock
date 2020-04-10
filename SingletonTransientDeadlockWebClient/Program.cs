using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SingletonTransientDeadlockWebClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press any key to send pack of concurrent requests or 'q' to exit");
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44314/");
            await httpClient.GetAsync("no-route");
            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine("Sending pack of concurrent requests...");
                var scopedTask = httpClient.GetAsync($"scopedroute");
                var sw = Stopwatch.StartNew();
                while ((double)sw.ElapsedTicks / Stopwatch.Frequency < 0.0285)
                    ;
                var singletonTask = httpClient.GetAsync($"singletonroute");
                await Task.WhenAll(scopedTask, singletonTask);
                Console.WriteLine("Press any key to send another pack of concurrent requests or 'q' to exit");
            }
        }
    }
}
