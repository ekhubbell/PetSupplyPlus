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

    public class EorderController : ControllerBase
    {
        GatherInfo info = new GatherInfo();

        // GET: api/<EorderController> get the data from the employee table
        [HttpGet]
        public IEnumerable<Eorder> Get(string key = "noValue", string search = "noValue")
        {
            var items = new List<Eorder>();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = "select  orders.orderID, orders.cust_ID, SUM(ordercontent.price) as subtotal, round(TotalCosts(orders.orderID),2)as total, orders.status\r\nfrom orders\r\njoin ordercontent on orders.orderid = ordercontent.orderID\r\ngroup by orders.orderID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    items.Add(new Eorder(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString()));
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

 


        [HttpPut("{id}")]
        public void Put([FromBody] string Value, string id)
        {

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("UPDATE orders set status= '{0}' where orderID = '{1}';", Value, id);
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



