using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostmanClone.Request
{
  public class PostRequest : Request
  {
    public override async Task<string> makeRequest
      (
      string url, 
      StringContent data
      )
    {
      try
      {
        HttpResponseMessage response = await client.PostAsync(url, data);

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
