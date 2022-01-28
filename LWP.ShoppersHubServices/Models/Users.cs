using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LWP.ShoppersHubServices.Models
{
    public class Users
    {
        [Required]
        public string EmailId { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required]
        public byte? RoleId { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
