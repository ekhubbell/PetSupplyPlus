using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using PetApi.Helpers;
using PetApi.Models;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        GatherInfo info = new GatherInfo();
        int? id;
        StateController stateCon = null;
        C_usernamesController c_userCon = null;
        string tableName = "customer";
        // this gets all the data from the customer table
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get(string key = "noValue", string search ="noValue")
        {
            var items = new List<Customer>();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
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

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "SELECT * FROM customer WHERE cust_ID = " +id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    item = new Customer(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString(), rdr[7].ToString(), rdr[8].ToString());
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
        [HttpPost]
        public void Post([FromBody] Customer cust)
        {
            Console.WriteLine("HELLO????");
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();
                if(id ==null)
                {
                    string sqlSelect = "select max(cust_id) FROM customer;";
                    MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, conn);
                    MySqlDataReader rdr = cmdSelect.ExecuteReader();
                    rdr.Read();
                    id = Int32.Parse(rdr[0].ToString());
                }
                id++;
                
                if (stateCon == null)
                {
                    stateCon = new StateController();
                }

                string sql = String.Format("insert into {0} values({1},'{2}','{3}','{4}','{5}',{6}, {7}, '{8}', '{9}');",tableName, id, cust.firstName, cust.lastName, cust.address, cust.city, cust.stateId, cust.email, cust.phone);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

                if(c_userCon == null)
                {
                    c_userCon = new C_usernamesController();
                }
                c_userCon.PostDirectly(new C_Usernames(id.ToString(), cust.email, cust.password));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        // PUT api/<ItemsController>/5 this is where to update
        [HttpPut("{id}")]
        public void Put([FromBody] string Value ,int id, string key)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("update customer set {0}= '{1}' where cust_id = {2};", key,Value, id);
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
