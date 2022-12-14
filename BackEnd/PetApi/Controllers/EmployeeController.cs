using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using PetApi.Helpers;
using PetApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        GatherInfo info = new GatherInfo();

        // GET: api/<EmployeeController> get the data from the employee table
        [HttpGet]
        public IEnumerable<Employee> Get(string key = "noValue", string search = "noValue")
        {
            var items = new List<Employee>();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "SELECT * FROM Employee";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    items.Add(new Employee(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString()));
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            return items;
        }

        [HttpGet("{id}")]
        public Employee Get(string id) // gets data from employee table for desired employee ID
        {
            Employee item = new Employee();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "SELECT * FROM employee WHERE employee_ID = '" + id + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    item = new Employee(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString());
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            return item;


        }



        //        // POST api/<ItemsController> this adds new items
        //        [HttpPost]
        //        public void Post([FromBody] string id, [FromBody] string fname, [FromBody] string lname, [FromBody] string mail, [FromBody] string phon)
        //        {
        //            MySqlConnection conn = new MySqlConnection(info.GetConnection());
        //            try
        //            {
        //                Console.WriteLine("Connecting...");
        //                conn.Open();

        //                string sql = String.Format("insert into employee value({0},\"{1}\",\"{2}\",{3},{4})", id, fname, lname, mail, phon);
        //                MySqlCommand cmd = new MySqlCommand(sql, conn);
        //                conn.Close();
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e.ToString());
        //            }
        //        }
        //        //need to finish the below sections...
        // PUT api/<ItemsController>/5 this is where to update
        [HttpPut("{id}")]
        public void Put([FromBody] string Value, string id, string key)
        {

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("UPDATE employee set {0}= '{1}' where employee_id = '{2}';", key, Value, id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
    

        //        // DELETE api/<ItemsController>/5
        //        [HttpDelete("{id}")]
        //        public void Delete([FromBody] string id, [FromBody] string fname, [FromBody] string lname, [FromBody] string mail, [FromBody] string phon)
        //        {
        //            MySqlConnection conn = new MySqlConnection(info.GetConnection());
        //            try
        //            {
        //                Console.WriteLine("Connecting...");
        //                conn.Open();

        //                string sql = String.Format("DELETE from employee", id, fname, lname, mail, phon);
        //                MySqlCommand cmd = new MySqlCommand(sql, conn);
        //                conn.Close();
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e.ToString());
        //            }
        //        }
        //    }
        //}

 