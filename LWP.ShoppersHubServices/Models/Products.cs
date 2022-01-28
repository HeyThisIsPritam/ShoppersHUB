using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LWP.ShoppersHubServices.Models
{ 
    public class Products
    {
        public string ProductId { get; set; }

        [RegularExpression(@"^[a-zA-Z]{4,100}")]
        public string ProductName { get; set; }
        [Required]
        public byte CategoryId { get; set; }
        [Required]
        [Range(minimum: 0, maximum: Double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public int QuantityAvailable { get; set; }
    }
}
