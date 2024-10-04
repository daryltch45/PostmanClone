namespace PostmanClone.Request
{
  public class APIaccess : IAPIaccess
  {
    private readonly HttpClient client;

    public APIaccess()
    {
      client = new HttpClient();
    }
    public async Task<string> getRequest(string url)
    {

      try
      {
        HttpResponseMessage response = await client.GetAsync(url);

        string responseData = await response.Content.ReadAsStringAsync();

        return responseData;
      }
      catch (HttpRequestException e)
      {
        return "Request Error";
      }

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
