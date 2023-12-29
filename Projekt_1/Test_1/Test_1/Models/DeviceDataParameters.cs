using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMKI.Models
{
    public class DeviceDataParameters
    {        
            public double DistanceMeters { get; set; }
            public double DistanceKilometers { get; set; }
            public long TimeDifferenceMiliseconds { get; set; }                   
            public double SpeedMetersPerSecond { get; set; }
            public double SpeedKilometersPerHour { get; set; }
    }
    
}
