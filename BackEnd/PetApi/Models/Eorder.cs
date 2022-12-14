namespace PetApi.Models
{
    public class Eorder
    {

        public string oID { get; set; }
        public string cID { get; set; }
        public string Subtotal { get; set; }
        public string Total { get; set; }
        public string Status { get; set; }

        public Eorder(string oid, string cid, string subtotal, string total, string status)
        {
            oID = oid;
            cID = cid;
            Subtotal = subtotal; 
            Total = total;
            Status = status;

        }
        public Eorder()
        {
            oID = "-1";
        }
    }
}
