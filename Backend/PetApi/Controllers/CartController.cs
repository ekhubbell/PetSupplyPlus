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

namespace PetApi.Controllers
{
      [Route("api/[controller]")]
        [ApiController]


    public class CartController : Controller

    {
            GatherInfo info = new GatherInfo();
            private string tableName = "CartContent";
            TableData tableData;

          
           

        [HttpGet("{orderID}")]
        public IEnumerable<CartContent> Get(int orderID)

        {
            var cartcont = new List<CartContent>();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {

                Console.WriteLine("Connecting to database...");
                conn.Open();
                string sql = String.Format("SELECT Item_name,description, items.price, ordercontent.Quantity FROM orders inner join ordercontent on orders.orderID = ordercontent.orderID inner join items on items.ItemId = ordercontent.itemID where paid != 'paid' and ordercontent.{0} = {1}; ", "orderID", orderID);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cartcont.Add(new CartContent(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString()));
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
            return cartcont;
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

