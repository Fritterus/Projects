using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSharing.Entities
{
    public class Car : BaseEntities
    {
        public decimal Cost { get; set; }
        public int ReleaseDate { get; set; }
        public string ImageURL { get; set; }
        public int Status { get; set; }
        public int MakeId { get; set; }
        public int CarModelId { get; set; }

    }
}
