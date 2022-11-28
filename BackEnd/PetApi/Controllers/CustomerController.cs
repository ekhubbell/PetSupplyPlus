using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using PetApi.Models;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {

        const string CONNSTR = "server=localhost;user=root;database=;port=3306;password=;";
        // this gets all the data from the customer table
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var items = new List<Customer>();

            MySqlConnection conn = new MySqlConnection(CONNSTR);
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "SELECT * FROM customer";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    items.Add(new Customer(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString(), rdr[7].ToString(), rdr[8].ToString()));
                }
                rdr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            return items;
        }
// this gets the data from the customer table depending on the desired cust_ID 
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            Customer item = new Customer();

            MySqlConnection conn = new MySqlConnection(CONNSTR);
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "SELECT * FROM customer WHERE cust_ID = " +id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    item = new Customer(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString, rdr[7].ToString, rdr[8].ToString);
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
// this goes into the Customer table and selects those with the desired first name
        // GET api/<CustomerController>/5
        [HttpGet("{fname}")]
        public IEnumerable<Customer> GetByfname(string fname)
        {
            var items = new List<Customer>();

            MySqlConnection conn = new MySqlConnection(CONNSTR);
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "SELECT * FROM customer WHERE firstName LIKE %\""+ fname +"\"%";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    items.Add(new Customer(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString, rdr[7].ToString, rdr[8].ToString));
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
// this gets the customer table and selects the data that have a certain state_ID
        [HttpGet("{id}")]
        public IEnumerable<Customer> GetByState(int id)
        {
            var items = new List<Customer>();

            MySqlConnection conn = new MySqlConnection(CONNSTR);
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "SELECT * FROM customer WHERE state_id = " +id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    items.Add(new Customer(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString, rdr[7].ToString, rdr[8].ToString));
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



        // POST api/<CustomerController> this adds new items to the customer table
        [HttpPost]
        public void Post([FromBody] string id, [FromBody] string fname, [FromBody] string lname, [FromBody] string addr, [FromBody] string cit, [FromBody] string s_id, [FromBody] string zip, [FromBody] string mail, [FromBody] string phon)
        {
            MySqlConnection conn = new MySqlConnection(CONNSTR);
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("insert into customer value({0},\"{1}\",\"{2}\",{3},{4})", id, fname, lname, addr, cit, s_id, zip, mail, phon);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //need2finish
        // PUT api/<ItemsController>/5 this is where to update
        [HttpPut("{id}")]
        public void Put([FromBody] string id, [FromBody] string fname, [FromBody] string lname, [FromBody] string addr, [FromBody] string cit, [FromBody] string s_id, [FromBody] string zip, [FromBody] string mail, [FromBody] string phon)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("UPDATE from customer", id, fname, lname, addr, cit, s_id, zip, mail, phon);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
//need2finish
        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete([FromBody] string id, [FromBody] string fname, [FromBody] string lname, [FromBody] string addr, [FromBody] string cit, [FromBody] string s_id, [FromBody] string zip, [FromBody] string mail, [FromBody] string phon)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("DELETE from customer", id, fname, lname, addr, cit, s_id, zip, mail, phon);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
