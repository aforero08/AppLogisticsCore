using AppLogistics.Common.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppLogistics.WebApp.Models.AccountViewModels
{
    public class ApplicationUserEditViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredField)]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredField)]
        [Phone]
        [DisplayName("Teléfono")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredField)]
        [EmailAddress]
        [DisplayName("Correo electrónico")]
        public string Email { get; set; }

        [DisplayName("Correo confirmado")]
        public bool EmailConfirmed { get; set; }

        [DisplayName("Último inicio de sesión")]
        public DateTime? LastLogin { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredField)]
        [DisplayName("Rol")]
        public string SelectedRol { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}