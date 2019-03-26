using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class Rate
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ActivityId { get; set; }
        public int? VehicleTypeId { get; set; }
        public decimal Price { get; set; }
        public int PercentCost { get; set; }
        public bool SplitFare { get; set; }

        public Activity Activity { get; set; }
        public Client Client { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
