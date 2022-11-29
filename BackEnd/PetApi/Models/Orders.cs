using System.ComponentModel.DataAnnotations;

namespace PetApi.Models
{
    public class Orders

    {
        [Key]
        public string OrderID { get; set; }

        public string Cust_ID { get; set; }

        public string EmployeeID { get; set; }

        public string EmployeeAction { get; set; }

        public string Paid { get; set; }

        public string Status { get; set; }

        public Orders(string orderid, string cust, string employeeid, string employeeaction, string paid, string status)
        {
            OrderID = orderid;
            Cust_ID = cust;
            EmployeeID = employeeid;
            EmployeeAction = employeeaction;
            Paid = paid;
            Status = status;
        }
        public Orders()
        {
            OrderID = "-1";
        }
    }
}