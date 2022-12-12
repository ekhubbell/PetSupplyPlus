using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using PetApi.Models;
using PetApi.Helpers;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System;
using PetApi.Helpers;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderContentController : ControllerBase

    {
        GatherInfo info = new GatherInfo();
        private string tableName = "OrderContent";
        TableData tableData;

        // GET: api/<OrderContentController>
        [HttpGet]
        public IEnumerable<OrderContent> Get()
        {
            var items = new List<OrderContent>();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                // Get all the data from the OrderContent table

                string sql = "SELECT * FROM OrderContent";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    items.Add(new OrderContent(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString()));
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


        //GET api/<OrderContentController>/5

        [HttpGet("{orderID}")]
        public OrderContent Get(int orderID)
        {
            OrderContent oc = new OrderContent();
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = String.Format("SELECT * FROM OrderContent WHERE {0} = {1} ", "orderID", orderID);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    oc = new OrderContent(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString());
                }
                rdr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return oc;

        }

            // POST api/<OrderContentController>

            [HttpPost]
            public void Post([FromBody] OrderContent oc)
            {
                MySqlConnection conn = new MySqlConnection(info.GetConnection());
                try
                {
                    Console.WriteLine("Connecting...");
                    conn.Open();
                    string sql = String.Format("insert into OrderContent value({0},{1},{2},{3})", oc.OrderID, oc.ItemID, oc.Quantity, oc.Price);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    conn.Close();
                }
            }



        // PUT api/<OrderContentController>/update

        [HttpPut("Put/{orderID}/{itemID}")]
        public void Put(int orderID, int itemID, string key, string value)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                tableData = info.getKeys("OrderContent");
                int index = tableData.name.IndexOf(key);
                int i = index;
                double num;
                if (index != -1 &&
                    ((tableData.datatype[index].Equals("int") && value.All(char.IsDigit)) || (!string.IsNullOrEmpty(value) && tableData.datatype[index].Equals("double") && Double.TryParse(value, out num))))
                {
                    string sql = String.Format("UPDATE OrderContent set {0} = {1} where orderID = {2} AND itemID = {3}",key,value, orderID, itemID);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                conn.Close();
            }
        }



        // DELETE api/<OrderContentController>/delete

        [HttpDelete("Delete/{orderID}/{itemID}")]
        public void Delete(int orderID, int itemID)
        {
            {
                MySqlConnection conn = new MySqlConnection(info.GetConnection());
                try
                {
                    Console.WriteLine("Connecting...");
                    conn.Open();

                    string sql = String.Format("DELETE from OrderContent WHERE orderID = {0} AND itemID ={1};", orderID, itemID);
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
}
