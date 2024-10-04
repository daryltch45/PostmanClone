using System.Text;

HttpClient client = new();



string url = "https://jsonplaceholder.typicode.com/posts";

var jsonData = new StringContent
  (
  "{\"title\":\"foo\"," +
  "\"body\":\"bar\"," +
  "\"userId\":1}",
  Encoding.UTF8, 
  "application/json"
  );

try
{
  HttpResponseMessage response = await client.PostAsync(url, jsonData);


  string responseData = await response.Content.ReadAsStringAsync(); 
}
catch(Exception e)
{
  Console.Write(e.ToString());  
}