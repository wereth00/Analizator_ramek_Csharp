using RAMKI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Program;

namespace RAMKI.Models
{
    public class DeviceData
    {
        public string Device { get; set; }
        public int Distance { get; set; }
        public long Timestamp { get; set; }
        public DateTimeOffset Date { get => DateTimeOffset.FromUnixTimeMilliseconds(Timestamp); }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public Slot Slot1 { get; set; }
        public Slot Slot2 { get; set; }
    }
}
