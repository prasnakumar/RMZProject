using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model.DataModel
{
    public class ZoneModel
    {
        [Key]
        public int Id { get; set; }

        public string ZoneName { get; set; }

        [Required]
        [ForeignKey("FacilityModel")]
        public int FloorId { get; set; }

        [Required]
        [ForeignKey("CityModel")]
        public int cityId { get; set; }

        [Required]
        [ForeignKey("BuildingModel")]
        public int  BuildingId { get; set; }

        [Required]
        [ForeignKey("FacilityModel")]
        public int FacilityId { get; set; }

            
    }
}
