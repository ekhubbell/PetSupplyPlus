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

    public class OrdersController : ControllerBase

    {

        GatherInfo info = new GatherInfo();
        private string tableName = "Orders";
    
// GET: api/<OrderContentController>
        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            var items = new List<Orders>();

            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();


// Get all the data from the OrderContent table

                string sql = "SELECT * FROM Orders";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    items.Add(new Orders(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString()));
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
        public Orders Get(int orderID)
        {
            Orders order = new Orders();
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = String.Format("SELECT * FROM Orders WHERE {0} = {1}", "orderID", orderID);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    order = new Orders(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString());
                }
                rdr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return order;
        }


        [HttpGet("Customer/{id}")]
        public List<Orders> GetCustomerOrders(int id)
        {
            List<Orders> orders = new List<Orders>();
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = String.Format("SELECT * FROM Orders WHERE {0} = {1}", "Cust_id", id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    orders.Add(new Orders(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString()));
                }
                rdr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return orders;
        }

        [HttpGet("Customer/cart/{id}")]
        public List<CartItem> GetCustomerCart(int id)
        {
            string custID = id.ToString();
            List<CartItem> items = new List<CartItem>();
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = String.Format("SELECT orders.orderID, items.itemID, ordercontent.quantity, items.price, items.item_name,items.description,ordercontent.price  FROM Orders INNER JOIN ordercontent ON orders.orderID=ordercontent.orderID INNER JOIN items ON ordercontent.itemID = items.itemID WHERE Cust_id = {0} AND paid != 'paid'", id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    items.Add(new CartItem(custID, rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString()));
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

        // POST api/<OrderContentController>

        [HttpPost]
        public void Post([FromBody] Orders order)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("insert into Orders value({0},{1},'{2}','{3}','{4}','{5}')", order.OrderID, order.Cust_ID, order.EmployeeID, order.EmployeeAction, order.Paid, order.Status);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
           
            }
        }




// PUT api/<OrdersController>/update

        [HttpPut("{orderID}")]
        public void Put([FromBody] Orders order, int orderID)
        {
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting...");
                conn.Open();

                string sql = String.Format("update Orders set Cust_id ={0}, EmployeeID = '{1}', EmployeeAction = '{2}', Paid = '{3}', Status = '{4}' where orderID = {5};", order.Cust_ID, order.EmployeeID, order.EmployeeAction, order.Paid, order.Status, orderID);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)

            {
                Console.WriteLine(e.ToString());
            
            }
        }




// DELETE api/<OrdersController>/delete

        [HttpDelete("{orderID}")]
        public void Delete(string orderID)
        {
            {
                MySqlConnection conn = new MySqlConnection(info.GetConnection());
                try
                {
                    Console.WriteLine("Connecting...");
                    conn.Open();

                    string sql = String.Format("DELETE from Orders where orderid = {0}", orderID);
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










