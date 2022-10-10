using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model.DataModel
{
    public class ElectricMeterModel
    {
        
        [Key]

        public int Id { get; set; }

        [ForeignKey("ZoneModel")]
        public int ZoneId { get; set; }

       [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int Cost { get; set; }
    
}

}
