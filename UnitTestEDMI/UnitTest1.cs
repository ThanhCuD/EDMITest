using EDMITest.Controllers;
using EDMITest.Models;
using EDMITest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace UnitTestEDMI
{
    [TestClass]
    public class ElectricMeterControllerTest
    {
        private ElectricMeterService service;
        private ElectricMeterController controller;
        public ElectricMeterControllerTest()
        {
            service = new ElectricMeterService();
            controller = new ElectricMeterController(service);
        }
        [TestMethod]
        public void Create()
        {
            try
            {
                ElectricMeterTestHelper.DeleteAllData();
                var model = new CreateElectricMeterParamModel()
                {
                    SerialNumber = "SerialNumber",
                    FirmwareVersion = "FirmwareVersion",
                    State = "State"
                };
                var result = controller.Create(model);
                EdmiContext dbContext = new EdmiContext();
                var statusCode = result as OkResult;
                var count = dbContext.ElectricMeters.Count();

                Assert.AreEqual(200, statusCode.StatusCode);
                Assert.AreEqual(1, count);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                ElectricMeterTestHelper.DeleteAllData();
            }
        }
        [TestMethod]
        public void GetByID()
        {
            try
            {
                ElectricMeterTestHelper.DeleteAllData();
                var item = ElectricMeterTestHelper.CreateItemData();
                var actionResult = controller.GetById(item.ID.ToString());
                var okObjectResult = actionResult as OkObjectResult;
                var electricMeter = okObjectResult.Value as ElectricMeter;
                Assert.AreEqual(200, okObjectResult.StatusCode);
                Assert.Equals(item, electricMeter);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }

    public class ElectricMeterTestHelper
    {
        public static void DeleteAllData()
        {
            EdmiContext dbContext = new EdmiContext();
            var data = dbContext.ElectricMeters.ToList();
            dbContext.ElectricMeters.RemoveRange(data);
            dbContext.SaveChanges();
        }
        public static ElectricMeter CreateItemData()
        {
            ElectricMeter item = new ElectricMeter()
            {
                FirmwareVersion = "TestCreate"
            };
            EdmiContext dbContext = new EdmiContext();
            dbContext.ElectricMeters.Add(item);
            dbContext.SaveChanges();
            var data = dbContext.ElectricMeters.First();
            return data;
        }
    }
}
