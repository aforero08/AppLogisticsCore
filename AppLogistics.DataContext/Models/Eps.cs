using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class Eps
    {
        public Eps()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nit { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
