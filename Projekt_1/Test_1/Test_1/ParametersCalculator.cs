using RAMKI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMKI
{
    internal class ParametersCalculator
    {
        public static double GetDistanceBetweenPoints(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            const double EarthRadiusMeters = 6371000;

            double lat1 = Deg2Rad(latitude1);
            double lon1 = Deg2Rad(longitude1);
            double lat2 = Deg2Rad(latitude2);
            double lon2 = Deg2Rad(longitude2);

            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;

            double a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = EarthRadiusMeters * c;
            return distance;
        }
        
        public static double CalculateDistance(DeviceData data1, DeviceData data2)
        {
            double lat1 = data1.Lat;
            double lon1 = data1.Lon;
            double lat2 = data2.Lat;
            double lon2 = data2.Lon;
            double distance = ParametersCalculator.GetDistanceBetweenPoints(lat1, lon1, lat2, lon2);
            return distance;
        }

        public static double CalculateTimeDifference(DeviceData data1, DeviceData data2)
        {
            long time1 = data1.Timestamp;
            long time2 = data2.Timestamp;
            return time2 - time1;
        }

        public static double CalculateSpeed(double distance, double timeDifference)
        {
            double timeInSeconds = timeDifference / 1000.0;
            double timeInHours = timeInSeconds / 3600;
            return timeDifference > 0 ? Math.Round(distance / timeInHours, 3) : 0;
        }
        
        private static double Deg2Rad(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
