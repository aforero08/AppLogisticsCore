using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientArea = new HashSet<ClientArea>();
            Rate = new HashSet<Rate>();
            Service = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int BranchOfficeId { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }

        public BranchOffice BranchOffice { get; set; }
        public ICollection<ClientArea> ClientArea { get; set; }
        public ICollection<Rate> Rate { get; set; }
        public ICollection<Service> Service { get; set; }
    }
}
