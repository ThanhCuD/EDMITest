using EDMITest.Controllers;
using EDMITest.Entity;
using EDMITest.Models;
using EDMITest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestEDMI
{
    [TestClass]
    public class ElectricMeterControllerTest
    {
        private ElectricMeterController controller;
        List<ElectricMeter> myEntities;
        public ElectricMeterControllerTest()
        {
            myEntities = new List<ElectricMeter>()
                {
                    new ElectricMeter { ID = 1, FirmwareVersion = "v 1", SerialNumber = "1234", State = "State" } ,
                    new ElectricMeter { ID = 2, FirmwareVersion = "v 2", SerialNumber = "1235", State = "State" },
                    new ElectricMeter { ID = 3, FirmwareVersion = "v 3", SerialNumber = "1236", State = "State" }
                };
            var dbContext = new Mock<EdmiContext>();
            var dbSet = GetQueryableMockDbSet(myEntities);
            dbContext.Setup(o => o.ElectricMeters).Returns(dbSet);
            var service = new ElectricMeterService(dbContext.Object);
            controller = new ElectricMeterController(service);
        }
        [TestMethod]
        public async Task GetAllData()
        {
            try
            {
                var actionResult = await controller.GetAll();
                var okObjectResult = actionResult as OkObjectResult;
                var listActual = okObjectResult.Value as List<SearchElectricMeterResultModel>;
                Assert.AreEqual(200, okObjectResult.StatusCode);
                Assert.AreEqual(myEntities.Count(), listActual.Count);
                var sortData = listActual.OrderBy(_ => _.Id).ToList();
                for (int i = 0; i < listActual.Count; i++)
                {
                    Assert.AreEqual(listActual[i].Id, myEntities[i].ID);
                    Assert.AreEqual(listActual[i].FirmwareVersion, myEntities[i].FirmwareVersion);
                    Assert.AreEqual(listActual[i].State, myEntities[i].State);
                    Assert.AreEqual(listActual[i].SerialNumber, myEntities[i].SerialNumber);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public async Task GetByID()
        {
            try
            {
                var actionResult = await controller.GetById("1");
                var okObjectResult = actionResult as OkObjectResult;
                var actual = okObjectResult.Value as ElectricMeter;
                var expect = myEntities.First(_ => _.ID == 1);
                Assert.AreEqual(200, okObjectResult.StatusCode);
                Assert.AreEqual(actual, expect);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public async Task CreateSuccess()
        {
            try
            {
                Assert.AreEqual(myEntities.Count, 3);
                var data = new CreateElectricMeterParamModel { FirmwareVersion = "v 4", SerialNumber = "1237", State = "State" };
                var actionResult = await controller.Create(data);
                var okObjectResult = actionResult as OkResult;
                var expect = myEntities.Count;
                Assert.AreEqual(200, okObjectResult.StatusCode);
                Assert.AreEqual(expect, 4);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #region private
        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }
        #endregion
    }
}
