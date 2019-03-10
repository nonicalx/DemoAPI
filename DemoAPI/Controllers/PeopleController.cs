using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sql_DBconnector;

namespace DemoAPI.Controllers
{
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();
        MySqlDB dB = new MySqlDB();

        public PeopleController()
        {
            
            var data = dB.Select();

            for (int i = 0; i < dB.Count(); i++)
            {
                people.Add(new Person { Id = data[0][i], FirstName = data[1][i], LastName = data[2][i], Email = data[3][i], PhoneNumber = data[4][i], Password = data[5][i] });
            }
            //people.Add(new Person { FirstName = "Ibukun", LastName = "Afe", Id = 1 });
            //people.Add(new Person { FirstName = "Victor", LastName = "Korode", Id = 2 });
            //people.Add(new Person { FirstName = "Jonathan", LastName = "Ekwere", Id = 3 });
        }
        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(string id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/People
        public void Post(Person value)
        {
            dB.Insert(value.FirstName,value.LastName,value.Email,int.Parse(value.PhoneNumber),value.Password);
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
