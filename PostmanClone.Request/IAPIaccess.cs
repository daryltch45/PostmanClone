namespace PostmanClone.Request
{
  public interface IAPIaccess
  {
    Task<string> getRequest(string url);
    bool IsValidUrl(string url);
  }
}