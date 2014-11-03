using System.Collections.Generic;
using System.Web.Http;
using ServerManager.Models;

namespace ServerManager.Controllers
{
    public class InstanceController : ApiController
    {
        // GET: api/Instance
        public IEnumerable<string> Get()
        {
          return ServerRepository.GetInstanceList();
        }
    }
}
