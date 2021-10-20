using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharing.Entities
{
    public class Statement : BaseEntities
    {
        public string EmployeeId { get; set; }
        public int OrderId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
