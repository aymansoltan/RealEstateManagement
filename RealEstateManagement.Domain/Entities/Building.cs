using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Entities
{
    public class Building : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int BuildingNumber { get; set; }

        public Guid OwnerId { get; set; }
        public Owner? Owner { get; set; }

        public ICollection<Floor> Floors { get; set; } = new List<Floor>();
    }
}
