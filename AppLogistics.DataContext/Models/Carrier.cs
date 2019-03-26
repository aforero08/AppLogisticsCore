using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class Carrier
    {
        public Carrier()
        {
            Service = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nit { get; set; }

        public ICollection<Service> Service { get; set; }
    }
}
