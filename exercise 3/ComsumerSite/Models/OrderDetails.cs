using System.ComponentModel.DataAnnotations;

namespace ComsumerSite.Models
{
    public class OrderDetails
    {
        [Required]
        [Display(Name = "Order Item 1")]
        public string Item1 { get; set; }
        
        [Display(Name = "Order Item 2")]
        public string Item2 { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Order Price")]
        public double Price { get; set; }
    }
}