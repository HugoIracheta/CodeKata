using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Code_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static void Run()
        {
            //neded variables, I left the positions configurables, for good mesure
            int commandPostition = 0;
            int namePosition = 1;
            int startTimePosition = 2;
            int endTimePosition = 3;
            int milesDrivenPosition = 4;
            List<Driver> driverList = new List<Driver>();
            String[] lines = new string[] { };

            //read file as a string array
            string startupPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "inputFile.txt");
            try
            {
                Console.WriteLine($"Searching file in: {startupPath}");
                lines = File.ReadAllLines(startupPath);
            }catch(Exception ex)
            {
                Console.WriteLine($"Couldn't locate the file '{startupPath}'");
                return;
            }

            //read every line in the file
            foreach (String line in lines)
            {
                String[] data = line.Split(' ');
                //Driver command or trip command
                if (data[commandPostition].ToLower() == "driver")
                {
                    Driver driver = new Driver();
                    driver.Name = data[namePosition];
                    driverList.Add(driver);
                }else if(data[commandPostition].ToLower() == "trip")
                {
                    Driver driver = driverList.Find(d => d.Name.Equals(data[namePosition]));
                    Trip trip = new Trip();
                    trip.StartTime = DateTime.Parse(data[startTimePosition]);
                    trip.EndTime = DateTime.Parse(data[endTimePosition]);
                    trip.MilesDriven = float.Parse(data[milesDrivenPosition]);

                    //validate we discard trips with less than 5 mph and more than 100 mph
                    if (trip.ValidateTrip())
                    {
                        driver.AddTrip(trip);
                    }
                }
            }
            //Sort list by total miles driven
            driverList.Sort(delegate (Driver a, Driver b)
            {
                if (a.TotalMilesDriven() == b.TotalMilesDriven()) return 0;
                else return b.TotalMilesDriven().CompareTo(a.TotalMilesDriven());
            });

            //Print the needed output
            driverList.ForEach(delegate (Driver driver)
            {
                Console.WriteLine($"{driver.Name}: {driver.TotalMilesDriven()} miles @ {driver.MilesPerHour()} mph");
            });
        }
    }
}
