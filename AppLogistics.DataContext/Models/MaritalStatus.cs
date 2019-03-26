using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class MaritalStatus
    {
        public MaritalStatus()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
