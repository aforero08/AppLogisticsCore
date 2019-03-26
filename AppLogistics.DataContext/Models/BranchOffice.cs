using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class BranchOffice
    {
        public BranchOffice()
        {
            Client = new HashSet<Client>();
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Client> Client { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
