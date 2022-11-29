using Microsoft.AspNetCore.Mvc;
using PetApi.Models;
using PetApi.Helpers;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypesController : ControllerBase
    {
        GatherInfo info = new GatherInfo();
        private string tableName = "pettypes";
        private string primaryKey = "type_ID";
        private TableData keyInfo;
        // GET: api/<PetTypesController>
        [HttpGet]
        public IEnumerable<PetType> Get()
        {
            List<PetType> petTypes = new List<PetType>();
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                conn.Open();

                string sql = string.Format("SELECT * FROM {0}", tableName);

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    petTypes.Add(new PetType(rdr[0].ToString(), rdr[1].ToString()));

                }
                rdr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
            return petTypes;
        }

        // GET api/<PetTypesController>/5
        [HttpGet("{id}")]
        public PetType Get(int id)
        {
            PetType petType = new PetType();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            primaryKey = info.getKeys(tableName).primary;
            try
            {
                conn.Open();
                string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", tableName, primaryKey, id);

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    petType = new PetType(rdr[0].ToString(), rdr[1].ToString());

                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            conn.Close();
            return petType;
        }

        // POST api/<PetTypesController>
        [HttpPost]
        public void Post([FromBody] PetType value)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("insert into {0} value({1},\"{2}\")",tableName, value.TypeID, value.TypeName);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // PUT api/<PetTypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value, string key)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            keyInfo = info.getKeys(tableName);
            primaryKey = keyInfo.primary;
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                keyInfo = info.getKeys(tableName);
                int index = keyInfo.name.IndexOf(key);
                if (index == -1)
                {
                    throw new Exception(string.Format("{0} is not a valid parameter", key));
                }
                else
                {
                    double num;
                    string temp = "";
                    if ((keyInfo.datatype[index].Equals("int") && value.All(char.IsDigit)) || (string.IsNullOrEmpty(value) && keyInfo.datatype[index].Equals("double") && Double.TryParse(value, out num)))
                    {
                        temp = "UPDATE {0} SET {1} ={2} WHERE {3} = {4}";
                    }
                    else
                    {
                        temp = "UPDATE {0} SET {1} ='{2}' WHERE {3} = {4}";
                    }
                    string sql = String.Format(temp, tableName, key, value, primaryKey, id);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // DELETE api/<PetTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            primaryKey = info.getKeys(tableName).primary;
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("DELETE FROM {0} WHERE {1} = {2}", tableName, primaryKey, id);
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
