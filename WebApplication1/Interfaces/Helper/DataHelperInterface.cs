using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Interfaces.Helper
{
    [ExcludeFromCodeCoverage]
    public  class DataHelperInterface
    {
        public string Type { get; set; }

        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public string meterType { get; set; }
        public float cost { get; set; }


    }
}
