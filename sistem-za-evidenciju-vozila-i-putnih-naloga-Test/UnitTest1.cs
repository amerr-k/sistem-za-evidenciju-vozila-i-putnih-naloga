using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Controllers;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Services;
using sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels;
using System.Collections.Generic;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<ICarsService> mockStudentService = new Mock<ICarsService>();
            mockStudentService.Setup(x => x.getAllCars()).Returns(getMockupCarsIndexVM());

            List<CarsIndexVM> ocekivani = new List<CarsIndexVM>
            {
                new CarsIndexVM {
                    CarId = 1,CarModel = "Skoda Fabia",
                    ChassisNumber = "123ASD",EngineNumber = "23",
                    EnginPowerKS = 23,EnginPowerKW = 32,
                    Fuel = Status.Recorded.ToString(),ProductionYear = 1990
                },
                new CarsIndexVM
                {
                    CarId = 2,CarModel = "Skoda Fabia",
                    ChassisNumber = "123ASD",EngineNumber = "23",
                    EnginPowerKS = 23,EnginPowerKW = 32,
                    Fuel = Status.Recorded.ToString(),ProductionYear = 1990
                }
            };


            CarsController cH = new CarsController(mockStudentService.Object);
            ViewResult vR = cH.Index() as ViewResult;
            List<CarsIndexVM> dobijeni = vR.Model as List<CarsIndexVM>;
            CollectionAssert.AreEqual(ocekivani, dobijeni, Comparer<CarsIndexVM>.Create((prvi, drugi) =>
                prvi.CarId == drugi.CarId && 
                prvi.CarModel == drugi.CarModel
                ? 0 : 1
            ));


        }




        [TestMethod]
        public void TestMethod2()
        {
        }


        public List<CarsIndexVM> getMockupCarsIndexVM()
        {
            List<CarsIndexVM> model = new List<CarsIndexVM>()
            {
                new CarsIndexVM
                { CarId = 1, CarModel = "Skoda Fabia",
                    ChassisNumber = "123ASD", EngineNumber = "23",
                    EnginPowerKS = 23, EnginPowerKW = 32,
                    Fuel = Status.Recorded.ToString(), ProductionYear = 1990 },
                new CarsIndexVM
                {
                    CarId = 2, CarModel = "Skoda Fabia",
                    ChassisNumber = "123ASD", EngineNumber = "23",
                    EnginPowerKS = 23, EnginPowerKW = 32,
                    Fuel = Status.Recorded.ToString(), ProductionYear = 1990
                }
            };
            return model;
        }
    }
}




