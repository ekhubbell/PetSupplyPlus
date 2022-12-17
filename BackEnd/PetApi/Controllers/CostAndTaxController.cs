using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PetApi.Helpers;
using PetApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostAndTaxController : ControllerBase
    {
        GatherInfo info = new GatherInfo();
        [HttpGet("TC/{orderID}")]
        public CostAndTax GetCT(int orderID)
        {
            CostAndTax ct = new CostAndTax(null, null, null);
            MySqlConnection conn = new MySqlConnection(info.GetConnection());
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = String.Format("SELECT sum(price), TotalCosts({1})-sum(price), TotalCosts({1})  FROM OrderContent WHERE {0} = {1} ", "orderID", orderID);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ct = new CostAndTax(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString());
                }
                rdr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            return ct;

        }
    }
}
