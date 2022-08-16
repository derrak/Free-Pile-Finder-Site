using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FreePileFinder.Models
{
  public class Pile
  {
    public int PileId { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool Availability { get; set; } = true;

    public string State { get; set; }

    public string City { get; set; }

    public double Lat { get; set; }

    public double Lng { get; set; }

    public string Zipcode { get; set; }

    // public static List<Pile> GetPiles(string apiKey)
    public static List<Pile> GetPiles(string apiKey)
    {
      var apiCallTask = ApiHelper.ApiCall(apiKey);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Pile> pileList = JsonConvert.DeserializeObject<List<Pile>>(jsonResponse["results"].ToString());

      return pileList;
    }
  }
}