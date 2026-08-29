using RealEstateManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Entities
{
    public class Document : AuditableEntity
    {
        public string Url { get; set; }

        public DocumentType DocumentType { get; set; } 
        public Guid RentalContractId { get; set; }
        public RentalContract? RentalContract { get; set; }
    }
}
