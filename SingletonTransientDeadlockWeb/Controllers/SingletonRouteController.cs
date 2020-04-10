using Microsoft.AspNetCore.Mvc;
using SingletonTransientDeadlockWeb.Client;

namespace SingletonTransientDeadlockWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SingletonRouteController : ControllerBase
    {
        public SingletonRouteController(Singleton singleton)
        {

        }

        public string Get()
        {
            return "singleton";
        }
    }
}