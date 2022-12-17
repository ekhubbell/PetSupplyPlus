namespace PetApi.Models
{
    public class CartItem
    {
        public string CustID { get; set; }
        public string OrderID { get; set; }

        public string ItemID { get; set; }

        public string Quantity { get; set; }

        public string Price { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }
        
        public string TotalPrice { get; set; }

        public CartItem(string CustID, string OrderID, string ItemID, string Quantity, string Price, string Name, string Desc, string TotalPrice)
        {
            this.CustID = CustID;
            this.OrderID = OrderID;
            this.ItemID = ItemID;
            this.Quantity = Quantity;
            this.Price = Price;
            this.Name = Name;
            this.Desc = Desc;
            this.TotalPrice = TotalPrice;
        }
    }
}
