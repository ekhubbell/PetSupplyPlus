using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using PetApi.Models;
using PetApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private string tableName = "states";
        private string specialKey = "state_abbr";
        private GatherInfo info = new GatherInfo();

        private TableData keys;
        // GET: api/<StateController>
        [HttpGet]
        public IEnumerable<State> Get()
        {
            List<State> states = new List<State>();
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = String.Format("SELECT * FROM {0}", tableName);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    states.Add(new State(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString()));
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            return states;

        }

        // GET api/<StateController>/5
        [HttpGet("abbr/{abbr}")]
        public State Get(string abbr)
        {
            State st = null;
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();
                string sql = String.Format("SELECT * FROM {0} WHERE {1} = '{2}'", tableName, specialKey, abbr);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                st = new State(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString());
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();

            return st;
        }

        [HttpGet("{id}")]
        public State GetById(string id)
        {
            State st = null;
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                keys = info.getKeys(tableName);
                Console.WriteLine("Connecting to database...");
                conn.Open();
                string sql = String.Format("SELECT * FROM {0} WHERE {1} = {2}", tableName, keys.primary, id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                st = new State(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString());
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();

            return st;
        }
        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] double tax)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();
                string sql = String.Format("UPDATE {0} SET tax = {2}", tableName, tax);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
        }
    }
}
