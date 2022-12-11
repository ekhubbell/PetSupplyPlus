namespace PetApi.Models
{
    public class URL
    {
        public string link { get; set; }
        public string accountType { get; set; } //0 for customer, //1 for employee
        public string userID { get; set; } 
        public URL(string link, string accountType, string userID)
        {
            this.link = link;
            this.accountType = accountType;
            this.userID = userID;

        }

    }


}
