using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using Org.BouncyCastle.Utilities;
using PetApi.Helpers;
using PetApi.Models;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_usernamesController : ControllerBase
    {
        GatherInfo info = new GatherInfo();

        // GET: api/<C_usernamesController>
        [HttpGet]
        public IEnumerable<C_Usernames> Get()

        {
            var userNames = new List<C_Usernames>();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {

                Console.WriteLine("Connecting to database...");
                conn.Open();
                string sql = "SELECT * FROM C_Username union select * from E_Username order by user_id +0 asc;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    userNames.Add(new C_Usernames(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString()));
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
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "SELECT * FROM C_Username WHERE C_Username = '" + username+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    login = new C_Usernames(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString());
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
        public URL checks(string username, string password)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "SELECT * FROM C_Username WHERE username = '" + username + "' and password = MD5('" + password + "');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        URL url = new URL("customer.html", "0", rdr[0].ToString());
                        rdr.Close();
                        conn.Close();
                        return url;
                    }
                    rdr.Close();
                }
                
                string sql1 = "SELECT * FROM E_Username WHERE username = '" + username + "' and password = MD5('" + password + "');";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                using (MySqlDataReader rdr1 = cmd1.ExecuteReader())
                {
                    if (rdr1.HasRows) { 
                        rdr1.Read();
                        URL url = new URL("employee.html", "1", rdr1[0].ToString());
                        rdr1.Close();
                        conn.Close();
                        return url;
                    }

                    rdr1.Close();
                }
                
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                
            }


            conn.Close();
            Console.WriteLine("Done.");
            return new URL("index.html", "", "");
        }



        //// PUT api/<C_UsernameController>/5 this is where to update passwords
        [HttpPut("{id}")]

        public void Put([FromBody] C_Usernames c_user, int id)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = String.Format("SELECT c_username, password FROM C_Username WHERE  userID= {0}", id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.HasRows)
                    {
                        rdr.Close();
                        string sqlupdate = String.Format("Update C_Username set password = md5('{1}') WHERE c_username = '{0}'", c_user.userName,c_user.password);
                        MySqlCommand cmdup = new MySqlCommand(sqlupdate, conn);
                        cmdup.ExecuteNonQuery();

                    }
                    else {
                        Console.WriteLine(sql);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
        }




            // POST api/<C-username Controller> this adds new customers 
            [HttpPost]
            public void Post([FromBody] C_Usernames c_user)
            {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("insert into C_userName value({0},'{1}',MD5('{2}'))", c_user.userID,c_user.userName,c_user.password);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        [HttpPost("dir")]
        public void PostDirectly(C_Usernames c_user)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("insert into C_userName value({0},'{1}',MD5('{2}'))", c_user.userID, c_user.userName, c_user.password);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        // DELETE api/<ItemsController>/5
        [HttpDelete("{C_id}")]
        public void Delete(int C_id)
        {
                MySqlConnection conn = new MySqlConnection(info.GetConnection());
                try
                {
                    Console.WriteLine("Connecting...");
                    conn.Open();

                    string sql = String.Format("delete from C_userName where userId = {0}", C_id);
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
