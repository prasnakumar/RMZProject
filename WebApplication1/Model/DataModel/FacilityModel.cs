using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.DataModel;

namespace WebApplication1.Model
{
    public class FacilityModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FacilityName { get; set; }

        public string LocationAddress { get; set; }

        public CityModel CityId {get;set; }

        public ICollection<BuildingModel> Building { get; set; }

        public ICollection<FloorModel> Floor { get; set; }
    }
}
