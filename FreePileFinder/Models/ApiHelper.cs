using System.Threading.Tasks;
using RestSharp;

namespace FreePileFinder.Models
{
  class ApiHelper
  {
    public static async Task<string> ApiCall(string apiKey)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"piles", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}