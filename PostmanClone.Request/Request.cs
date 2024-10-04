using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostmanClone.Request
{
  public abstract class Request
  {
    public readonly HttpClient client = new();
    public abstract Task<string> makeRequest
      (
      string url,
      StringContent data
      );
  }
}
