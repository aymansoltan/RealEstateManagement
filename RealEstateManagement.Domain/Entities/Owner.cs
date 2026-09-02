using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Entities
{
    public class Owner : AuditableEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string IdentityUserId { get; set; }
        public ICollection<Building> Buildings { get; set; } = new List<Building>();

    }
}
