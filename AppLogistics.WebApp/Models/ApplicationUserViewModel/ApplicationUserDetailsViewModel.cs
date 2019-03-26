using System;
using System.ComponentModel;

namespace AppLogistics.WebApp.Models.ApplicationUserViewModel
{
    public class ApplicationUserDetailsViewModel
    {
        public string Id { get; set; }

        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Teléfono")]
        public string Phone { get; set; }

        [DisplayName("Correo electrónico")]
        public string Email { get; set; }

        [DisplayName("Correo confirmado")]
        public bool EmailConfirmed { get; set; }

        [DisplayName("Último inicio de sesión")]
        public DateTime? LastLogin { get; set; }

        [DisplayName("Rol")]
        public string CurrentRol { get; set; }
    }
}