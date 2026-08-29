using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Entities
{
    public class Floor : BaseEntity
    {
        public int FloorNumber { get; set; }

        public Guid BuildingId { get; set; }
        public Building? Building { get; set; }

        public ICollection<Unit> Units { get; set; } = new List<Unit>();

    }
}
