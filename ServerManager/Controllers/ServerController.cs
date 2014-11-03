using System.Collections.Generic;
using System.Web.Http;
using ServerManager.Models;

namespace ServerManager.Controllers
{
    public class ServerController : ApiController
    {
        
        // GET: api/Server/5
        public IEnumerable<Server> Get(string id)
        {
          return ServerRepository.ByInstance(id);
        }

        // POST: api/Server
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Server/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Server/5
        public void Delete(int id)
        {
        }
    }
}
