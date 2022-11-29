//using Microsoft.AspNetCore.Mvc;
//using MySql.Data.MySqlClient;
//using Org.BouncyCastle.Utilities;
//using PetApi.Models;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace PetApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]

//    public class ItemsController : ControllerBase
//    {

//        const string CONNSTR = "server=localhost;user=root;database=;port=3306;password=;";
        
//        // GET: api/<ItemsController>
//        [HttpGet]
//        public IEnumerable<Item> Get()
//        {
//            var items = new List<Item>();

//            MySqlConnection conn = new MySqlConnection(CONNSTR);
//            try
//            {
//                Console.WriteLine("Connecting to database...");
//                conn.Open();

//                string sql = "SELECT * FROM items";
//                MySqlCommand cmd = new MySqlCommand(sql, conn);
//                MySqlDataReader rdr = cmd.ExecuteReader();
//                while (rdr.Read())
//                {
//                    items.Add(new Item(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString()));
//                }
//                rdr.Close();
//            }
//            catch(Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            conn.Close();
//            Console.WriteLine("Done.");
//            return items;
//        }

//        [HttpGet("{id}")]
//        public Item Get(int id)
//        {
//            Item item = new Item();

//            MySqlConnection conn = new MySqlConnection(CONNSTR);
//            try
//            {
//                Console.WriteLine("Connecting to database...");
//                conn.Open();

//                string sql = "SELECT * FROM items WHERE Item_ID = " +id;
//                MySqlCommand cmd = new MySqlCommand(sql, conn);
//                MySqlDataReader rdr = cmd.ExecuteReader();
//                while (rdr.Read())
//                {
//                    item = new Item(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString());
//                }
//                rdr.Close();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            conn.Close();
//            Console.WriteLine("Done.");
//            return item;


//        }

//        // GET api/<ItemsController>/5
//        [HttpGet("{name}")]
//        public IEnumerable<Item> GetByName(string name)
//        {
//            var items = new List<Item>();

//            MySqlConnection conn = new MySqlConnection(CONNSTR);
//            try
//            {
//                Console.WriteLine("Connecting to database...");
//                conn.Open();

//                string sql = "SELECT * FROM items WHERE item_Name LIKE %\""+ name +"\"%";
//                MySqlCommand cmd = new MySqlCommand(sql, conn);
//                MySqlDataReader rdr = cmd.ExecuteReader();
//                while (rdr.Read())
//                {
//                    items.Add(new Item(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString()));
//                }
//                rdr.Close();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            conn.Close();
//            Console.WriteLine("Done.");
//            return items;
//        }

//        [HttpGet("{id}")]
//        public IEnumerable<Item> GetByType(int id)
//        {
//            var items = new List<Item>();

//            MySqlConnection conn = new MySqlConnection(CONNSTR);
//            try
//            {
//                Console.WriteLine("Connecting to database...");
//                conn.Open();

//                string sql = "SELECT * FROM items WHERE petType = " +id;
//                MySqlCommand cmd = new MySqlCommand(sql, conn);
//                MySqlDataReader rdr = cmd.ExecuteReader();
//                while (rdr.Read())
//                {
//                    items.Add(new Item(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString()));
//                }
//                rdr.Close();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            conn.Close();
//            Console.WriteLine("Done.");
//            return items;
//        }



//        // POST api/<ItemsController> this adds new items
//        [HttpPost]
//        public void Post([FromBody] string id, [FromBody] string name, [FromBody] string desc, [FromBody] string quant, [FromBody] string petType)
//        {
//            MySqlConnection conn = new MySqlConnection(CONNSTR);
//            try
//            {
//                Console.WriteLine("Connecting...");
//                conn.Open();

//                string sql = String.Format("insert into items value({0},\"{1}\",\"{2}\",{3},{4})", id, name, desc, quant, petType);
//                MySqlCommand cmd = new MySqlCommand(sql, conn);
//                conn.Close();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }
//        }

//        // PUT api/<ItemsController>/5 this is where to update
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<ItemsController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
