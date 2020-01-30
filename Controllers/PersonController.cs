using System;
using System.Collections.Generic;
using ASPNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASPNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : ControllerBase
    {
        static public List<Person> people = new List<Person>();

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            if (System.IO.File.Exists("data.json"))
            {
                String JSONtxt = System.IO.File.ReadAllText("data.json");
                people = JsonConvert.DeserializeObject<List<Person>>(JSONtxt);
            }

            return Ok(people);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Person> Get(int id)
        {
            if (System.IO.File.Exists("data.json"))
            {
                String JSONtxt = System.IO.File.ReadAllText("data.json");
                people = JsonConvert.DeserializeObject<List<Person>>(JSONtxt);
            }

            if (id >= 0 && id < people.Count)
            {
                return Ok(people[id]);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody]Person person)
        {
            people.Add(person);

            string json = JsonConvert.SerializeObject(people.ToArray());

            System.IO.File.WriteAllText("data.json", json);

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            people.RemoveAt(id);

            string json = JsonConvert.SerializeObject(people.ToArray());

            System.IO.File.WriteAllText("data.json", json);

            return Ok();
        }

    }
}