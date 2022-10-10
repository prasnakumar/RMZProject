using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Interfaces.Helper;
using WebApplication1.Interfaces.ServiceInterface;
using WebApplication1.Model;
using WebApplication1.Model.DataModel;
using WebApplication1.Services;
using Xunit;

namespace RMZUnitTesting
{
    public class RMZSiteTesting
    {

        private readonly IRMZInterface _rms;

  
     
      

        public RMZSiteTesting(){
            _rms = A.Fake<IRMZInterface>();
          
           
            }
        [Fact]
        public async Task FacilityTest()
        {
            //Arrange
         
            A.CallTo(() => _rms.facilityModels(A<string>.Ignored)).Returns(55);


            //Act
            int addata = (int)await _rms.facilityModels("RMZ");

            //Assert
            Assert.Equal(addata, 55);
        }

        [Fact]
        public async Task ZoneTest()
        {
            //Arrange
            var data_1 = new List<DataHelperInterface>();
            var data = new DataHelperInterface() {
                Type = "#1",
                startTime = DateTime.ParseExact("30/01/2022", "dd/MM/yyyy", null),
                endTime = DateTime.ParseExact("30/10/2022", "dd/MM/yyyy", null),
                meterType = "Electric",
                cost = 2003
            };
            data_1.Add(data);
            A.CallTo(() => _rms.Zones(A<int>.Ignored, A<DateTime>.Ignored, A<DateTime>.Ignored)).Returns(
              Task.FromResult(data_1));
            //Act 
            var values =await  _rms.Zones(1, DateTime.ParseExact("30/01/2022", "dd/MM/yyyy", null), DateTime.ParseExact("30/10/2022", "dd/MM/yyyy", null));

            //Assert
            Assert.Equal(values, data_1);
        }

        [Fact]
        public async Task Building()
        {
            //Arrange
            var dataBuilding = new List<DataHelperInterface>();
            var data = new DataHelperInterface()
            {
                Type = "#1",
                startTime = DateTime.ParseExact("30/01/2022", "dd/MM/yyyy", null),
                endTime = DateTime.ParseExact("30/10/2022", "dd/MM/yyyy", null),
                meterType = "Electric",
                cost = 2003
            };
            dataBuilding.Add(data);
            A.CallTo(()=>_rms.Building(A<int>.Ignored, A<DateTime>.Ignored, A<DateTime>.Ignored)).Returns(
              Task.FromResult(dataBuilding));
         
            //Act 
            var values = await _rms.Building(1, DateTime.ParseExact("30/01/2022", "dd/MM/yyyy", null), DateTime.ParseExact("30/10/2022", "dd/MM/yyyy", null));

            //Assert
            Assert.Equal(values, dataBuilding);


        }


        [Fact]
        public async Task Facility()
        {
            //Arrange
            var dataFacility = new List<DataHelperInterface>();
            var data = new DataHelperInterface()
            {
                Type = "#1",
                startTime = DateTime.ParseExact("01/01/2022", "dd/MM/yyyy", null),
                endTime = DateTime.ParseExact("01/10/2022", "dd/MM/yyyy", null),
                meterType = "Electric",
                cost = 2003
            };
            dataFacility.Add(data);
            A.CallTo(() => _rms.Facility(A<int>.Ignored, A<DateTime>.Ignored, A<DateTime>.Ignored)).Returns(
              Task.FromResult(dataFacility));

            //Act 
            var values = await _rms.Facility(1, DateTime.ParseExact("01/01/2022", "dd/MM/yyyy", null), DateTime.ParseExact("01/10/2022", "dd/MM/yyyy", null));

            //Assert
            Assert.Equal(values, dataFacility);


        }

    }
}
