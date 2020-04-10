using Microsoft.AspNetCore.Mvc;
using SingletonTransientDeadlockWeb.Client;

namespace SingletonTransientDeadlockWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScopedRouteController : ControllerBase
    {
        public ScopedRouteController(TypedHttpClient httpClient)
        {

        }

        public string Get()
        {
            return "scoped";
        }
    }
}