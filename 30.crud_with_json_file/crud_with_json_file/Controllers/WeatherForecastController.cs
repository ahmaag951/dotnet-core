using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace crud_with_json_file.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private string _jsonFilePath = "countries.json";

        [HttpGet]
        public string Get()
        {
            // if you have a specefic object in the json file

            //var jsonObject = JObject.Parse(json);

            //if (jsonObject == null)
            //{
            //    return "Error in file";
            //}

            //var countryJson = jsonObject["country"];
            //Country country = countryJson.ToObject<Country>();
            //Country country2 = JsonConvert.DeserializeObject<Country>(countryJson.ToString());

            //GetCountries();
            //AddCountry(new Country { Id = 60, Name = "Singafora" });
            //UpdateCountry(1, "the new Egypt");
            DeleteCountry(1);

            return "Hello";
        }

        private void AddCountry(Country country)
        {
            var json = System.IO.File.ReadAllText(_jsonFilePath);
            var jsonObj = JObject.Parse(json);
            var countriesArray = jsonObj.GetValue("countries") as JArray;

            var countryObject = (JObject)JToken.FromObject(country);
            countriesArray.Add(countryObject);

            jsonObj["countries"] = countriesArray;

            var countriesJson = JsonConvert.SerializeObject(jsonObj);
            System.IO.File.WriteAllText(_jsonFilePath, countriesJson);
        }

        private void UpdateCountry(int id, string name)
        {
            var json = System.IO.File.ReadAllText(_jsonFilePath);
            var jsonObj = JObject.Parse(json);
            var countriesArray = jsonObj.GetValue("countries") as JArray;

            var countryObject = countriesArray.Children<JObject>().FirstOrDefault(obj => (int)obj["id"] == id);
            countryObject["name"] = name;

            jsonObj["countries"] = countriesArray;

            var countriesJson = JsonConvert.SerializeObject(jsonObj);
            System.IO.File.WriteAllText(_jsonFilePath, countriesJson);
        }

        private void DeleteCountry(int id)
        {
            var json = System.IO.File.ReadAllText(_jsonFilePath);
            var jsonObj = JObject.Parse(json);
            var countriesArray = jsonObj.GetValue("countries") as JArray;

            var countryObject = countriesArray.Children<JObject>().FirstOrDefault(obj => (int)obj["id"] == id);

            countriesArray.Remove(countryObject);

            var countriesJson = JsonConvert.SerializeObject(jsonObj);
            System.IO.File.WriteAllText(_jsonFilePath, countriesJson);
        }

        private List<Country> GetCountries()
        {
            var json = System.IO.File.ReadAllText(_jsonFilePath);
            var jsonObj = JObject.Parse(json);
            var countriesArray = jsonObj.GetValue("countries") as JArray;

            var countries = countriesArray.ToObject<List<Country>>();

            return countries;
        }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
