using System.ComponentModel.DataAnnotations;

namespace PetApi.Models
{
    public class CartContent

    {
        [Key]
        public string ItemID { get; set; }

        public string ItemDescription { get; set; }

     

        public string Price { get; set; }
        public string Quantity { get; set; }

        public CartContent(string itemId, string itemDescrip, string quant, string price)
        {
            
            ItemID = itemId;
            ItemDescription = itemDescrip;
            Quantity = quant;
            Price = price;

        }
        public CartContent()
        {
            
            ItemID = "-1";
        }
        public static implicit operator string(CartContent v)
        {
            throw new NotImplementedException();
        }
    }
}
