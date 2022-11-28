using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Org.BouncyCastle.Utilities;
using PetApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_usernamesController : ControllerBase
    {
        const string CONNSTR = "server=localhost;user=root;database=;port=3306;password=Cosplayer2!;";

        // GET: api/<C_usernamesController>
        [HttpGet]
        public IEnumerable<C_Usernames> Get()

        {
            var userNames = new List<C_Usernames>();

            MySqlConnection conn = new MySqlConnection(CONNSTR);
            try
            {

                Console.WriteLine("Connecting to database...");
                conn.Open();
                string sql = "SELECT * FROM C_Username union select * from E_Username";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    userNames.Add(new C_Usernames(rdr[0].ToString(), rdr[1].ToString()));
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            return userNames;
        }


        // GET api/<C_usernamesController>/5
        [HttpGet("{username}")]
        public C_Usernames Get(string username)

        {
            C_Usernames login = new C_Usernames();
            MySqlConnection conn = new MySqlConnection(CONNSTR);
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "SELECT * FROM C_Username WHERE Username = " + username;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    login = new C_Usernames(rdr[0].ToString(), rdr[1].ToString());
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            return login;
        }
        [HttpGet("{username}/log")]
        public string checks(string username, string password)
        {
            MySqlConnection conn = new MySqlConnection(CONNSTR);
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "SELECT * FROM C_Username WHERE Username = " + username + "and password = " + password;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows) { return "URL USER LOGIN"; }

                string sql1 = "SELECT * FROM E_Username WHERE Username = " + username + "and password = " + password;
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                MySqlDataReader rdr1 = cmd1.ExecuteReader();
                if (rdr1.HasRows) { return "URL employee LOGIN"; }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            return "error - possibly redirect to url for login error";
        }
        // PUT api/<ItemsController>/5 this is where to update
        [HttpPut("{id}")]
        public void Put(string userName, [FromBody] string password)
        {
            MySqlConnection conn = new MySqlConnection(CONNSTR);
            Console.WriteLine("Connecting to database...");
            conn.Open();

            string sql = "SELECT * FROM C_Username WHERE Username = " + userName + "and password = " + password;
            string sqlupdate1 = "update C_Username set password =" + password;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                MySqlCommand cmdCus = new MySqlCommand(sqlupdate1, conn);
                MySqlDataReader rdrCus = cmdCus.ExecuteReader();

                ;
            }

            string sqlEmployee = "SELECT * FROM E_Username WHERE Username = " + userName + "and password = " + password;
            string sqlupdateEmployee = "update E_Username set password =" + password;
            MySqlCommand cmd1 = new MySqlCommand(sqlEmployee, conn);
            MySqlDataReader rdr1 = cmd1.ExecuteReader();
            if (rdr1.HasRows)
            {
                MySqlCommand cmdEmploy = new MySqlCommand(sqlEmployee, conn);
                MySqlDataReader rdrCus = cmdEmploy.ExecuteReader();
            }



        }


    }
}
