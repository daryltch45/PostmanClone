namespace PostmanClone.Request
{
  public enum RequestType { GET, POST, SET, PUT }
  public interface IAPIaccess
  {
    Task<string> getRequest(
      string url, 
      RequestType requestType
      );
    bool IsValidUrl(string url);
  }
}