using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class CityModel
    {
        [Key]

        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }

        public string Rmz { get; set; }

        public ICollection<FacilityModel> Facilites { get; set; }


    }
}
