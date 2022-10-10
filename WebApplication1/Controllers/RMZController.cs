using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Interfaces.Helper;
using WebApplication1.Interfaces.ServiceInterface;

namespace WebApplication1.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class RMZController : Controller
    {
        private readonly IRMZInterface _data;
            public RMZController(IRMZInterface data)
        {
            _data = data;

        }
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        [HttpGet]
        [Route("GetSiteInfo")]
        public async Task<IActionResult> Value(DateTime startDate, DateTime endDate, string facilityInformation,string type )
        {
        
            var  facility =await  _data.facilityModels(facilityInformation);
            if (facility == null)
            {
                return BadRequest("No Facility");
            }
            else
            {
                int facilityID = (int)facility;
                if (type == "Building")
                {
                    List<DataHelperInterface> zoneData = await _data.Building(facilityID, startDate, endDate);
                    return Ok(zoneData);
                }
                else if (type == "Facility")
                {
                    var zoneData = await _data.Facility(facilityID, startDate, endDate);
                    return Ok(zoneData);
                }
                else if (type == "Zones")
                {
                    var zoneData = await _data.Zones(facilityID, startDate, endDate);
                    return Ok(zoneData);

                }
                else
                {
                    return BadRequest("Wrong Option");
                }
            }
            
          
        }
    }
}
