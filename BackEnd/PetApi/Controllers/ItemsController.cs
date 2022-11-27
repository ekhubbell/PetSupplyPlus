using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using PetApi.Models;
using PetApi.Helpers;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ItemsController : ControllerBase
    {
        private string tableName = "items";
        private string primaryKey = "item_Id";
        private string specialKey = "item_name";
        private GatherInfo info = new GatherInfo();

        private List<string> keys = null;
        // GET: api/<ItemsController>
        [HttpGet]
        public IEnumerable<Item> Get(string searchBy = "noValue", string searchWord = "noValue")
        {
            var items = new List<Item>();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();
                string sql = string.Format("SELECT * FROM {1}", tableName);
                if (!searchBy.Equals("noValue"))
                {
                    keys = info.getKeys(tableName);
                    if (keys.Contains(searchBy))
                    {
                        if (searchBy.Equals(specialKey))
                        {
                            sql = string.Format("SELECT * FROM {0} WHERE {1} LIKE '%{2}%'", tableName, searchBy, searchWord);
                        }
                        else
                        {
                            sql = string.Format("SELECT * FROM {2} WHERE {0} = {1}", searchBy, searchWord, tableName);
                        }
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("{0} is not a valid parameter", searchBy));
                    }
                }
                

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    items.Add(new Item(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString()));
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
        public Item Get(int id)
        {
            Item item = new Item();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = string.Format("SELECT * FROM {0} WHERE {2} = {1}", tableName, id, primaryKey);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    item = new Item(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString());
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

        // POST api/<ItemsController> this adds new items
        [HttpPost]
        public void Post([FromBody] Item item)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("insert into {5} value({0},\"{1}\",\"{2}\",{3},{4})", item.Item_ID, item.Name, item.Desc, item.Quantity, item.PetType, tableName);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // PUT api/<ItemsController>/5 this is where to update
        [HttpPut("{Value}")]
        public void Put(int id, [FromBody] string value, string key)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                keys = info.getKeys(tableName);
                if (!keys.Contains(key))
                {
                    throw new Exception(string.Format("{0} is not a valid parameter", key));
                }
                
                string sql = String.Format("UPDATE {3} SET {0} ={1} WHERE {4} = {2}", key, value, id, tableName, primaryKey);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("DELETE from {0} SET WHERE {2} = {1}",tableName, id, primaryKey);
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
