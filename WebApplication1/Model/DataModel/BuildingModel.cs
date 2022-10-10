using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model.DataModel
{
    public class BuildingModel
    {
        [Key]
        public int Id { get; set; }

        public string BuildName { get; set; }

        public FacilityModel FacilityId { get; set; }

        public ICollection<FloorModel> Floor { get; set; }


     
    }
}
