using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Runtime.ExceptionServices;
using System.Data.Common;


namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            // Some of the TODO's are done for you to get you started. 

            logger.LogInfo("Log initialized");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
            // Optional: Log an error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            // This will display the first item in your lines array
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Use the Select LINQ method to parse every line in lines collection
            var locations = lines.Select(parser.Parse).ToArray();


            // Complete the Parse method in TacoParser class first and then START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. 
            ITrackable TacoBell1 = new TacoBell();
            ITrackable TacoBell2 = new TacoBell();
            // These will be used to store your two Taco Bells that are the farthest from each other.

            // TODO: Create a `double` variable to store the distance
            double distanceBell = 0;
            // TODO: Add the Geolocation library to enable location comparisons: using GeoCoordinatePortable;
            // Look up what methods you have access to within this library.

            // NESTED LOOPS SECTION----------------------------

            // FIRST FOR LOOP -
            // TODO: Create a loop to go through each item in your collection of locations.
            // This loop will let you select one location at a time to act as the "starting point" or "origin" location.
            // Naming suggestion for variable: `locA`
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];

                double LatitudeA = locA.Location.Latitude;
                double LongitudeA = locA.Location.Longitude;

               // Console.WriteLine($"Starting TacoBell: {locA}");
                var corA = new GeoCoordinate(LatitudeA, LongitudeA);
                for(int j = 0; j < locations.Length; j++)
                {
                    if (i != j)
                    {
                        var locB = locations[j];

                        double latitudeB = locB.Location.Latitude;
                        double longitudeB = locB.Location.Longitude;
                       // Console.WriteLine($"Second Location {locB}");
                        var corB = new GeoCoordinate(latitudeB, longitudeB);

                         double CurrentBell = corA.GetDistanceTo(corB);
                        if (CurrentBell > distanceBell)
                        {
                            distanceBell = CurrentBell;
                            TacoBell1 = locA;
                            TacoBell2 = locB;
                        }
                    }
                }

            }
            Console.WriteLine($"Farthest TacoBell: {TacoBell1.Name} and {TacoBell2.Name} with a distance of {distanceBell} ");
            // TODO: Once you have locA, create a new Coordinate object called `corA` with your locA's latitude and longitude.

            // SECOND FOR LOOP -
            // TODO: Now, Inside the scope of your first loop, create another loop to iterate through locations again.
            // This allows you to pick a "destination" location for each "origin" location from the first loop. 
            // Naming suggestion for variable: `locB`

            // TODO: Once you have locB, create a new Coordinate object called `corB` with your locB's latitude and longitude.

            // TODO: Now, still being inside the scope of the second for loop, compare the two locations using `.GetDistanceTo()` method, which returns a double.
            // If the distance is greater than the currently saved distance, update the distance variable and the two `ITrackable` variables you set above.

            // NESTED LOOPS SECTION COMPLETE ---------------------

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            // Display these two Taco Bell locations to the console.



        }
    }
}
