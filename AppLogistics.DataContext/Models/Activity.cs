using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Rate = new HashSet<Rate>();
            Service = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Rate> Rate { get; set; }
        public ICollection<Service> Service { get; set; }
    }
}
