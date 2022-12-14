using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PetApi.Helpers;
using PetApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class E_usernameController : ControllerBase
    {
        GatherInfo info = new GatherInfo();

        // GET: api/<E_usernameController>
        [HttpGet]
        public IEnumerable<E_Usernames> Get()
        {
            var userNames = new List<E_Usernames>();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {

                Console.WriteLine("Connecting to database...");
                conn.Open();
                string sql = "SELECT * FROM E_Username order by user_id +0 asc;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    userNames.Add(new E_Usernames(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString()));
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

        
       
        // POST api/<E_usernameController> //add new employees
        [HttpPost]
        public void Post([FromBody] E_Usernames e_user)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("insert into e_username value('{0}','{1}',MD5('{2}'))", e_user.userID, e_user.userName, e_user.password);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // PUT api/<E_usernameController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] E_Usernames e_user, int id)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());

            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = String.Format("SELECT username, user_password FROM E_Username WHERE  ID= '{0}'", id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {

                    if (rdr.HasRows)
                    {
                        rdr.Close();
                        string sqlupdate = String.Format("Update E_Username set user_password = md5('{1}') WHERE username = '{0}'", e_user.userName, e_user.password);
                        MySqlCommand cmdup = new MySqlCommand(sqlupdate, conn);
                        cmdup.ExecuteNonQuery();

                    }
                    else
                    {
                        Console.WriteLine(sql);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
        }

            // DELETE api/<E_usernameController>/5
            [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("delete from E_userName where Id = '{0}'", id);
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
