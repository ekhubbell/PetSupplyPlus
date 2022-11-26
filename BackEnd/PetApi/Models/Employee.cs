using System.ComponentModel.DataAnnotations;

namespace PetApi.Models
{
    public class Employee
    {
        [Key]
        public string employee_ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public Employee(string id, string fname, string lname, string mail, string phon)
        {
            Item_ID = id;
            firstName = fname;
            lastName = lname;
            email = mail;
            phone = phon;
        }
        public Employee()
        {
            employee_ID = "-1";
        }
    }
}
