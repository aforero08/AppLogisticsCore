using System;
using System.Collections.Generic;

namespace AppLogistics.DataContext.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Holding = new HashSet<Holding>();
        }

        public int Id { get; set; }
        public int InternalCode { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BornDate { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? RetirementDate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyContactPhone { get; set; }
        public int MaritalStatusId { get; set; }
        public int AfpId { get; set; }
        public int EpsId { get; set; }
        public int BranchOfficeId { get; set; }
        public bool Cv { get; set; }
        public bool DocumentCopy { get; set; }
        public bool Photos { get; set; }
        public bool MilitaryIdCopy { get; set; }
        public bool LaborCertification { get; set; }
        public bool PersonalReference { get; set; }
        public bool DisciplinaryBackground { get; set; }
        public bool KnowledgeTest { get; set; }
        public bool AdmissionTest { get; set; }
        public bool Contract { get; set; }
        public bool InternalRegulations { get; set; }
        public bool EndownmentLetter { get; set; }
        public bool CriticalPosition { get; set; }
        public string Comments { get; set; }

        public Afp Afp { get; set; }
        public BranchOffice BranchOffice { get; set; }
        public DocumentType DocumentType { get; set; }
        public Eps Eps { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public ICollection<Holding> Holding { get; set; }
    }
}
