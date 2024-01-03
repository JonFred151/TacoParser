using System;
using System.Runtime;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log error message and return null
                return null;
            }
            double Lati = 0.0;
            double Longi = 0.0;
            // TODO: Grab the latitude from your array at index 0
            // You're going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            int indexToConvert = 0;

            if (indexToConvert >= 0 && indexToConvert < cells.Length)
            {
                try
                {
                     Lati = double.Parse(cells[indexToConvert]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("This String is not Convertable");
                }
            }

            // TODO: Grab the longitude from your array at index 1
            // You're going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            int dexToConvert = 1;

            if (dexToConvert >= 0 && dexToConvert < cells.Length)
            {
                try
                {
                     Longi = double.Parse(cells[dexToConvert]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("This String is not Convertable");
                }
            }

            // TODO: Grab the name from your array at index 2
            var TacoName = cells[2];



            // TODO: Create an instance of the Point Struct
            // TODO: Set the values of the point correctly (Latitude and Longitude) 
            var point = new Point();
            point.Latitude = Lati;
            point.Longitude = Longi;

            // TODO: Create an instance of the TacoBell class
            // TODO: Set the values of the class correctly (Name and Location)
            var TacoBell =new TacoBell();
            TacoBell.Name = TacoName;
            TacoBell.Location = point;

           
            // TODO: Then, return the instance of your TacoBell class,
            // since it conforms to ITrackable

            return TacoBell;
        }
    }
}
