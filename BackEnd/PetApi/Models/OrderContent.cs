using System.ComponentModel.DataAnnotations;

namespace PetApi.Models
{
    public class OrderContent

    {
        [Key]
        public string OrderID { get; set; }

        public string ItemID { get; set; }

        public string Quantity { get; set; }

        public string Price { get; set; }

        public OrderContent(string orderid, string itemid, string quantity, string price)
        {
            OrderID = orderid;
            ItemID = itemid;
            Quantity = quantity;
            Price = price;

        }
        public OrderContent()
        {
            OrderID = "-1";
            ItemID = "-1";
        }
    }
}
