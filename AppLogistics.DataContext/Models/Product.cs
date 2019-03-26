using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class Product
    {
        public Product()
        {
            Service = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Service> Service { get; set; }
    }
}
