using Code_Kata;
using NUnit.Framework;
using System;

namespace CodeKataTest
{
    public class TripSpeedTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TripNotValidIfSpeedUnder5MPH()
        {
            Trip trip = new Trip();
            trip.StartTime = DateTime.Now;
            trip.EndTime = DateTime.Now.AddMinutes(60);
            trip.MilesDriven = 4;
            Assert.IsFalse(trip.ValidateTrip());
        }

        [Test]
        public void TripNotValidIfSpeedOver100MPH()
        {
            Trip trip = new Trip();
            trip.StartTime = DateTime.Now;
            trip.EndTime = DateTime.Now.AddMinutes(60);
            trip.MilesDriven = 101;
            Assert.IsFalse(trip.ValidateTrip());
        }

        [Test]
        public void TripValidIfSpeedOver4MPHAndUnder101()
        {
            Trip trip = new Trip();
            trip.StartTime = DateTime.Now;
            trip.EndTime = DateTime.Now.AddMinutes(60);
            trip.MilesDriven = 67;
            Assert.IsTrue(trip.ValidateTrip());
        }
    }
}