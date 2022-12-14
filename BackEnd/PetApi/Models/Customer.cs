using System.ComponentModel.DataAnnotations;

namespace PetApi.Models
{
    public class Customer
    {
        [Key]
        public string custId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string stateId { get; set; }
        public string zipcode { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }

        public Customer(string id, string fname, string lname, string addr, string cit, string s_id, string zip, string mail, string phon, string password = null)
        {
            custId = id;
            firstName = fname;
            lastName = lname;
            address = addr;
            city = cit;
            stateId = s_id;
            zipcode = zip;
            email = mail;
            phone = phon;
            this.password = password;
        }
        public Customer()
        {
            custId = "-1";
        }
    }
}
