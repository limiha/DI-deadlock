using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using SingletonTransientDeadlockWeb;
using Xunit;

namespace SingletonTransientDeadlockTest
{
    public class DeadlockTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public DeadlockTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task Test()
        {
            var client = _factory.CreateClient();
            var scopedTask = client.GetAsync("scopedroute");
            Wait(0.031);
            var singletonTask = client.GetAsync("singletonroute");
            await Task.WhenAll(scopedTask, singletonTask);
        }

        private void Wait(double seconds)
        {
            var sw = Stopwatch.StartNew();
            while ((double)sw.ElapsedTicks / Stopwatch.Frequency < seconds)
                ;
        }
    }
}