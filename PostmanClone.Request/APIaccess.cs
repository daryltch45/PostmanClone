using System;

namespace PostmanClone.Request
{
  public class APIaccess : IAPIaccess
  {
    public async Task<string> makeRequest
      (
      string url, 
      StringContent data, 
      RequestType requestType
      )
    {
      string response = string.Empty; 
      switch( requestType )
      {
        case RequestType.GET:
          response = await new GetRequest().makeRequest(url);
          break;
        
        case RequestType.POST:
          response = await new PostRequest().makeRequest(url, data);
          break; 
      }

      return response;
    }

    public bool IsValidUrl(string url)
    {
      if (string.IsNullOrEmpty(url)) return false;

      bool output = Uri.TryCreate(url, UriKind.Absolute, out Uri uri) &&
                    (uri.Scheme == Uri.UriSchemeHttps);

      return output;
    }
  }
}
