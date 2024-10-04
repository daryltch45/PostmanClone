namespace PostmanClone.Request
{
  public enum RequestType { GET, POST, SET, PUT }
  public interface IAPIaccess
  {
    Task<string> makeRequest(
      string url,
      StringContent data,
      RequestType requestType
      );

    public bool IsValidUrl(string url); 
  }
}