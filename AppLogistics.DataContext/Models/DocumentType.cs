using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
