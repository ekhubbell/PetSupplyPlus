using MySql.Data.MySqlClient;
using PetApi.Models;

namespace PetApi.Helpers
{
    public class GatherInfo
    {

        private const string CONNSTR = "server=localhost;user=root;database=petsupplyplus;port=3306;password=Reillyj18!;";
        private const string DBNAME = "petsupplyplus";
        public TableData getKeys(string table)
        {
            MySqlConnection conn = new MySqlConnection(CONNSTR);
            MySqlConnection conn2 = new MySqlConnection(CONNSTR);
            try
            {

                Console.WriteLine("Connecting to database...");
                conn.Open();

                string sql = string.Format("SELECT COLUMN_NAME, DATA_TYPE  FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}';", DBNAME, table);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                
                List<string> keyName = new List<string>();
                List<string> dataType = new List<string>();
                while (rdr.Read())
                {
                    keyName.Add(rdr[0].ToString());
                    dataType.Add(rdr[1].ToString());
                }
                rdr.Close();

                string sql2 =string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.key_column_usage WHERE table_schema = '{0}' AND CONSTRAINT_NAME = 'PRIMARY' AND TABLE_NAME = '{1}';", DBNAME, table);
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlDataReader rdr2 = cmd.ExecuteReader();
                rdr2.Read();
                string primary = rdr2[0].ToString();

                TableData key = new TableData(keyName, dataType, primary);


                rdr2.Close();
                conn.Close();

                Console.WriteLine("Done.");
                return key;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
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
