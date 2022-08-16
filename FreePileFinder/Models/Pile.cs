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

    public static List<Pile> GetPiles()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Pile> pileList = JsonConvert.DeserializeObject<List<Pile>>(jsonResponse.ToString());

      // JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      // List<Pile> pileList = JsonConvert.DeserializeObject<List<Pile>>(jsonResponse.ToString());

      return pileList;
    }
    public static Pile GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Pile pile = JsonConvert.DeserializeObject<Pile>(jsonResponse.ToString());

      return pile;
    }

    public static void Post(Pile pile)
    {
      string jsonPile = JsonConvert.SerializeObject(pile);
      var apiCallTask = ApiHelper.Post(jsonPile);
    }

    public static void Put(Pile pile)
    {
      string jsonPile = JsonConvert.SerializeObject(pile);
      var apiCallTask = ApiHelper.Put(pile.PileId, jsonPile);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}