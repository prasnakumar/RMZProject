using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces.Helper;
using WebApplication1.Interfaces.ServiceInterface;
using WebApplication1.Model;
using WebApplication1.Model.DataModel;

namespace WebApplication1.Services
{
    public class RMZService : IRMZInterface
    {
        public readonly DataContext _data;
        public RMZService(DataContext data)
        {
            _data = data;
        }

       

      

        public async Task<int?> facilityModels(string name)
        {
            var Facilty =await _data.Facility.Where(data => data.FacilityName == name).FirstOrDefaultAsync();
            if (Facilty == null)
            {
                return null;
            }
            return Facilty.Id;

        }

        public async  Task<List<DataHelperInterface>> Zones(int id, DateTime startTime, DateTime endTime)
        {
            var zone_check = await _data.Zone.Where(zone => zone.FacilityId == id).ToListAsync();
            List<DataHelperInterface> zoneLevel=new List<DataHelperInterface>();
            foreach (var i in zone_check)
            {
                var zoneValue = await _data.Zone.Where(zone => zone.Id == i.Id).ToListAsync();
                var electric = await zoneMeterElectric(zone_check, startTime, endTime, i.ZoneName);
                zoneLevel.Add(electric);
                var water = await zoneMeterWater(zone_check, startTime, endTime, i.ZoneName);
                zoneLevel.Add(water);


            }


            return zoneLevel;
           
        }
    

    public async Task<List<DataHelperInterface>> Building(int id,DateTime startTime, DateTime endTime)
    {
        var building = await _data.Building.Where(p => p.FacilityId.Id == id).ToListAsync();
            List<DataHelperInterface> facilityLevel = new List<DataHelperInterface>();

            foreach (var i in building)
        {
            var zone_check = await _data.Zone.Where(zone => zone.BuildingId == i.Id).ToListAsync();
                var electric = await zoneMeterElectric(zone_check, startTime, endTime, i.BuildName);
                facilityLevel.Add(electric);
                var water = await zoneMeterWater(zone_check, startTime, endTime,i.BuildName);
                facilityLevel.Add(water);



            }
        return facilityLevel;

    }

    public async Task<List<DataHelperInterface>> Facility(int id,DateTime startTime,DateTime endTime)
    {
        var facilitylist = await _data.Facility.Where(p => p.Id == id).FirstOrDefaultAsync();
        var listZone = new List<ZoneModel>();
        List<DataHelperInterface> facilityLevel = new List<DataHelperInterface>();

            var zone_check = await _data.Zone.Where(zone => zone.FacilityId == facilitylist.Id).ToListAsync();
            var electric =await  zoneMeterElectric(zone_check, startTime, endTime, facilitylist.FacilityName);
            facilityLevel.Add(electric);
            var water = await zoneMeterWater(zone_check, startTime, endTime, facilitylist.FacilityName);
            facilityLevel.Add(water);





            return facilityLevel;

        }

        public async Task<DataHelperInterface> zoneMeterElectric(List<ZoneModel> zone, DateTime startTime, DateTime endTime, string type)
        {
            DataHelperInterface electricSaveValue = new DataHelperInterface();
            electricSaveValue.cost = 0;
            foreach (var j in zone)
            {
                var ZonesElectric = await _data.ElectricMeter.Where(p => p.ZoneId == j.Id && p.Date > startTime && p.Date <= endTime).ToListAsync();
                ZonesElectric.ForEach(meter => electricSaveValue.cost += meter.Cost);
                electricSaveValue.startTime = startTime;
                electricSaveValue.endTime = endTime;
                electricSaveValue.Type = type;
                electricSaveValue.meterType = "Electric";
            }
            return electricSaveValue;
        }
        public async Task<DataHelperInterface> zoneMeterWater(List<ZoneModel> zone, DateTime startTime, DateTime endTime, string type)
        {
            DataHelperInterface waterSaveValue = new DataHelperInterface();
            waterSaveValue.cost = 0;
            foreach (var j in zone)
            {
                var ZonesElectric = await _data.WaterMeter.Where(p => p.ZoneId == j.Id && p.Date > startTime && p.Date <= endTime).ToListAsync();
                ZonesElectric.ForEach(meter => waterSaveValue.cost += meter.Cost);
                waterSaveValue.startTime = startTime;
                waterSaveValue.endTime = endTime;
                waterSaveValue.Type = type;
                waterSaveValue.meterType = "Water";
            }
            return waterSaveValue;
        }


    }
}

