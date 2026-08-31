using RealEstateManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Entities
{
    public class RentalContract : AuditableEntity
    {


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentAmount { get; set; }
        public decimal SecurityDeposit { get; set; }
        public RentalContractStatus Status { get; set; } = RentalContractStatus.Active;
        
        public Guid TenantId { get; set; }
        public Tenant? Tenant { get; set; }


        public Guid UnitId { get; set; }
        public Unit? Unit { get; set; }

        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
