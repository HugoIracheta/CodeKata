using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Code_Kata
{
    class Driver
    {
        public String Name { get; set; }
        List<Trip> Trips { get; set; }

        //sums all the trips mileage
        public double TotalMilesDriven()
        {
            if(this.Trips == null)
            {
                return 0;
            }
            float total = 0;
            total = Trips.Sum(trip => trip.MilesDriven);

            return Math.Round(total);
        }

        //get total miles from all trips and the total time of all trips
        public double MilesPerHour()
        {
            if (this.Trips == null)
            {
                return 0;
            }
            double total = 0;
            double totalMiles = this.TotalMilesDriven();
            double totalTime = Trips.Sum(t => t.TripTime());
            total = totalMiles / totalTime;
            return Math.Round(total);
        }

        public void AddTrip(Trip trip)
        {
            if(this.Trips == null)
            {
                this.Trips = new List<Trip>();
            }
            this.Trips.Add(trip);
        }
    }
}
