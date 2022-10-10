using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Interfaces.Helper;
using WebApplication1.Interfaces.ServiceInterface;
using Xunit;

namespace RMZUnitTesting
{
    public class Controller
    {
        private readonly RMZController rMZController;
        private readonly IRMZInterface _fakeservice;

        public Controller()
        {
            _fakeservice = A.Fake<IRMZInterface>();
            rMZController = new RMZController(_fakeservice)
            {
                ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }
            };
            rMZController.ControllerContext.HttpContext.Request.Headers["authorization"] = "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";
        }

        [Fact]
        public void  checkController()
        {
            //Arrange
            var data_1 = new List<DataHelperInterface>();
            var data = new DataHelperInterface()
            {
                Type = "#1",
                startTime = DateTime.ParseExact("30/01/2022", "dd/MM/yyyy", null),
                endTime = DateTime.ParseExact("30/10/2022", "dd/MM/yyyy", null),
                meterType = "Electric",
                cost = 2003
            };
            data_1.Add(data);
            A.CallTo(() => _fakeservice.facilityModels(A<string>.Ignored)).Returns(1);
            A.CallTo(() => _fakeservice.Zones(A<int>.Ignored, A<DateTime>.Ignored, A<DateTime>.Ignored)).Returns(
              Task.FromResult(data_1));
            //Act 
        
            var response =  rMZController.Value( DateTime.ParseExact("30/01/2022", "dd/MM/yyyy", null), DateTime.ParseExact("30/10/2022", "dd/MM/yyyy", null),"","Building").Result;
            var okResult = response as OkObjectResult;
            //Assert
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode) ;

        }

    }
}
