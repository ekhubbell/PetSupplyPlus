using MySql.Data.MySqlClient;
using PetApi.Models;

namespace PetApi.Helpers
{
    public class GatherInfo
    {

        private const string CONNSTR = "server=localhost;user=root;database=petsupplyplus;port=3306;password=;";
        private const string DBNAME = "petsupplyplus";
        public List<string> getKeys(string table)
        {
            List<string> keys = new List<string>();

            MySqlConnection conn = new MySqlConnection(CONNSTR);
            try
            {
                Console.WriteLine("Connecting to database...");
                conn.Open();
                string sql = string.Format("SELECT COLUMN_NAME  FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_SCHEMA = {0} AND TABLE_NAME = {1};", DBNAME, table);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    keys.Add(rdr[0].ToString());
                }
                rdr.Close();

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("Done.");
            return keys;
        }

        public string GetConnection()
        {
            return CONNSTR;
        }

        public GatherInfo()
        {

        }
    }
}
