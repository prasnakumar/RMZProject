using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model.DataModel
{
    public class WaterMeterModel
    {
        [Key]

        public int Id { get; set; }

        [ForeignKey("ZoneModel")]
        public int ZoneId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

       public int Cost { get; set; }
    }
}
