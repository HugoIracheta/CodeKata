using System;
using System.Collections.Generic;
using System.Text;

namespace Code_Kata
{
    class Trip
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float MilesDriven { get; set; }

        public float TripTime(){
            float time = 0;
            TimeSpan diff = EndTime.Subtract(StartTime);
            time = (float) diff.TotalMinutes / 60;
            return time;
        }
        
        //validation for miles per hour
        public bool ValidateTrip()
        {
            return (this.MilesDriven / this.TripTime() >= 5 && this.MilesDriven / this.TripTime() <= 100);
        }
    }
}
