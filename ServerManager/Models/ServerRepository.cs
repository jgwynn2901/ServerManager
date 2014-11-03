using System.Collections.Generic;
using System.Linq;

namespace ServerManager.Models
{
  public class ServerRepository
  {
    static private List<string> _instanceList;
    static private readonly object SynchLock = new object();
    /// <summary>
    /// Retrieve servers for a given instance.
    /// </summary>
    /// <param name="instance">The instance.</param>
    /// <returns></returns>
    static public IEnumerable<Server> ByInstance(string instance)
    {
      var results = new DbClassLibrary.ActiveRecords.Servers();
      if (!string.IsNullOrEmpty(instance))
      {
        results.Filter = string.Format("INSTANCE='{0}'", instance.ToLower());
      }
      results.Order = "INSTANCE,SERVER_NAME";
      return results.Results()
        .Select(a => new Server
        {
          Id = a.ServerId,
          Instance = a.DatabaseInstance,
          IpAddress = a.IpAddress,
          Name = a.ServerName,
          Role = a.Role,
          Uri = a.Uri,
          Description = a.Description
        });
    }

    /// <summary>
    /// Gets the (cached) list of instances.
    /// </summary>
    /// <returns></returns>
    static public List<string> GetInstanceList()
    {
      if (_instanceList != null && _instanceList.Count > 0) return _instanceList;
      lock (SynchLock)
      {
        if (_instanceList == null)
        {
          _instanceList = new List<string>();
        }
        var results = new DbClassLibrary.ActiveRecords.Servers {Order = "INSTANCE"};
        var list = results.Results()
          .Where(a => !string.IsNullOrWhiteSpace(a.DatabaseInstance))
          .Select(a => a.DatabaseInstance)
          .Distinct();
        _instanceList.AddRange(list.ToList());
      }
      return _instanceList;
    }

  }
}