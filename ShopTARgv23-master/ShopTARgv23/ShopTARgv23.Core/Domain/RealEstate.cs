using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.Domain
{
    public class RealEstate
    {
        public Guid? Id { get; set; }
        public string Location { get; set; }
        public double Size { get; set; }
        public int RoomNumber { get; set; }
        public string BuildingType { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
