using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model.DataModel
{
    public class FloorModel
    {
        [Key]
        public int Id { get; set; } 
        public string FloorName { get; set; }

        public BuildingModel Building { get; set; }

        public FacilityModel FacilityId { get; set; }


    }
}
