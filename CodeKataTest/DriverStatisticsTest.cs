using Code_Kata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKataTest
{
    class DriverStatisticsTest
    {
        Driver driver = new Driver();
        [SetUp]
        public void Setup()
        {
            driver = new Driver();
            driver.Name = "Bob";
            Trip trip = new Trip();
            trip.StartTime = DateTime.Now;
            trip.EndTime = DateTime.Now.AddMinutes(60);
            trip.MilesDriven = 30;
            driver.AddTrip(trip);
            trip = new Trip();
            trip.StartTime = DateTime.Now;
            trip.EndTime = DateTime.Now.AddMinutes(60);
            trip.MilesDriven = 65;
            driver.AddTrip(trip);
        }

        [Test]
        public void DriverTotalMilesDrivenTest()
        {
            Assert.AreEqual((double) 95, driver.TotalMilesDriven());
        }

        [Test]
        public void DriverMilesPerHourTest()
        {
            Assert.AreEqual(driver.MilesPerHour(), 48);
        }
    }
}
