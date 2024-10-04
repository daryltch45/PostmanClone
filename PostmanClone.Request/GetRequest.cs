using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostmanClone.Request
{
  public class GetRequest : Request
  {
    public override async Task<string> makeRequest
      (
      string url, 
      StringContent data = null
      )
    {
      try
      {
        HttpResponseMessage response = await client.GetAsync(url);

        string responseData = await response.Content.ReadAsStringAsync();

        return responseData;
      }
      catch (Exception e)
      {
        return "Error: " + e.Message;
      }
    }
  }
}

