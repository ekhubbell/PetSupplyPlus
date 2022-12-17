namespace PetApi.Models
{
    public class Cart
    {
        public string orderID;
        public string custID;
        public CartItem[] items;

        public Cart(string orderID, string custID, CartItem[] items)
        {
            this.orderID = orderID;
            this.custID = custID;
            this.items = items;
        }
    }
}
