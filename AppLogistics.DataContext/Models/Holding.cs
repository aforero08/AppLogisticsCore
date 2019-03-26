using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class Holding
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Price { get; set; }

        public Employee Employee { get; set; }
        public Service Service { get; set; }
    }
}
