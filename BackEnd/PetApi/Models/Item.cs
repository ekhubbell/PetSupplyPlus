using System.ComponentModel.DataAnnotations;

namespace PetApi.Models
{
    public class Item
    {
        [Key]
        public string Item_ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Quantity { get; set; }
        public string PetType { get; set; }

        public Item(string id, string name, string desc, string quantity, string petType)
        {
            Item_ID = id;
            Name = name;
            Desc = desc;
            Quantity = quantity;
            PetType = petType;
        }
        public Item()
        {
            Item_ID = "-1";
        }
    }
}
