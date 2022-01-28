using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LWP.ShoppersHubServices.Models
{
    public class Categories
    {
        [Required]
        public byte CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
