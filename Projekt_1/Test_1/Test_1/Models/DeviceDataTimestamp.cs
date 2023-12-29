using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMKI.Models
{
    internal class DeviceDataTimestamp
    {
        public DeviceDataTimestamp(DeviceData deviceData)
        {
            Device = deviceData.Device;
            Distance = deviceData.Distance;
            Timestamp = deviceData.Timestamp;
            Lat = deviceData.Lat;
            Lon = deviceData.Lon;
            Slot1 = deviceData.Slot1;
            Slot2 = deviceData.Slot2;
        }
        public string Device { get; set; }
        public int Distance { get; set; }
        public long Timestamp { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public Slot Slot1 { get; set; }
        public Slot Slot2 { get; set; }
    }
}
