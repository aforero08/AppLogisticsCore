using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class Service
    {
        public Service()
        {
            Holding = new HashSet<Holding>();
        }

        public int Id { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int ClientId { get; set; }
        public int? ClientAreaId { get; set; }
        public int ActivityId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductQuantity { get; set; }
        public int? VehicleTypeId { get; set; }
        public string VehicleNumber { get; set; }
        public int? CarrierId { get; set; }
        public string ExternalId { get; set; }
        public decimal FullPrice { get; set; }
        public decimal HoldingPrice { get; set; }
        public string Comments { get; set; }

        public Activity Activity { get; set; }
        public Carrier Carrier { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
        public VehicleType VehicleType { get; set; }
        public ICollection<Holding> Holding { get; set; }
    }
}
