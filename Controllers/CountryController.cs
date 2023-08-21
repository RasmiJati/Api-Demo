using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        //country controller for every request is different so we use static in list below 
        static List<Country> countries = new List<Country>();  //blank collection

        //Get api/<CountryController>
        [HttpGet(Name = "GetCountry")]
        public IEnumerable<Country> Get()
        {
            return countries;
        }


        //Get api/<CountryController>/5
        [HttpGet("{id}")]
        public Country Get(int id)
        {
            return countries.FirstOrDefault(c=> c.Id == id);
        }

        //POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] Country country)
        {
            countries.Add(country);
        }

        //PUT api/CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Country country)
        {
            int i = countries.FindIndex(c => c.Id == id);
            if (i >= 0)
            {
                countries[i] = country;
            }
        }

        //DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            countries.RemoveAll(c => c.Id == id);
        }
    }
}
