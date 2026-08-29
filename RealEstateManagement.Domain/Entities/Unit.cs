using RealEstateManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Domain.Entities
{
    public class Unit : BaseEntity
    {
        public int UnitNumber { get; set; }
        public float Area { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public UnitStatus Status { get; set; } = UnitStatus.Available;

        public Guid FloorId { get; set; }
        public Floor? Floor { get; set; }

        public ICollection<RentalContract> RentalContracts { get; set; } = new List<RentalContract>();
    }
}
