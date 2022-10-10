using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces.Helper;
using WebApplication1.Model;
using WebApplication1.Model.DataModel;

namespace WebApplication1.Interfaces.ServiceInterface
{
 
    public interface IRMZInterface
    {
   
        public  Task<int?> facilityModels(string id);

        public Task<List<DataHelperInterface>> Zones(int id,DateTime startTime, DateTime endTime);

        public Task<List<DataHelperInterface>> Building(int id,DateTime startTime, DateTime endTime);
        public Task<List<DataHelperInterface>> Facility(int id,DateTime startTime,DateTime endTime);

    }
}
