using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingYourPackage.Domain.Data.Repositories;
using PingYourPackage.API.Controllers;

namespace PingYourPackage.API.Test.Controllers
{    
    [TestClass]
    public class ShipmentsControllerTest
    {
        ShipmentRepository repo = new ShipmentRepository(new PingYourPackage.Domain.Data.PingYourPackageEntities());
        [TestMethod]
        public void Get()
        {
            // Arrange
            Domain.Contracts.IShipmentsControllerLogic controller = new Domain.Api.ShipmentsControllerLogic(repo);
            ShipmentsController apiController = new ShipmentsController((Domain.Api.ShipmentsControllerLogic)controller);

            // Act
            var result = apiController.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Headers.Count());
            //Assert.AreEqual(100, result.Content.Headers.ElementAt(0).);

        }

        //[TestMethod]
        //public void GetById()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    string result = controller.Get(5);

        //    // Assert
        //    Assert.AreEqual("value", result);
        //}

        //[TestMethod]
        //public void Post()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Post("value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Put()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Put(5, "value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Delete()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Delete(5);

        //    // Assert
        //}
    }
}
