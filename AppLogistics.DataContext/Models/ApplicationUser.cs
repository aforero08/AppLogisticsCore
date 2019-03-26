using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppLogistics.DataContext.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [PersonalData]
        public DateTime? LastLogin { get; set; }
    }
}
