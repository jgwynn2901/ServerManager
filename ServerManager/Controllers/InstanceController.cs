using System.Collections.Generic;
using System.Web.Http;
using ServerManager.Models;

namespace ServerManager.Controllers
{
    public class InstanceController : ApiController
    {
        // GET: api/Instance
        public IEnumerable<string> Get(string id)
        {
          return ServerRepository.GetInstanceList(id);
        }
    }
}
