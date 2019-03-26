using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class ClientArea
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }

        public Client Client { get; set; }
    }
}
