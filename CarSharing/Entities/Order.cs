using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharing.Entities
{
    public class Order : BaseEntities
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public int Status { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }
    }
}
