using System.ComponentModel.DataAnnotations;

namespace PetApi.Models
{
    public class CostAndTax
    {
        [Key]
        public string SubTotal { get; set; }
        public string Tax { get; set; }
        public string Total { get; set; }

        public CostAndTax(string subTotal, string tax, string total)
        {
            SubTotal = subTotal;
            Tax = tax;
            Total = total;
        }
    }
}
