using System;
using RAMKI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMKI
{
    public class DeviceDataProcessor
    {
        public Tuple<List<DeviceData>, List<DeviceData>> FilterAndSortData(List<DeviceData> inputList)
        {
            List<DeviceData> nonZeroCoordinates = new List<DeviceData>();
            List<DeviceData> zeroCoordinates = new List<DeviceData>();

            foreach (var item in inputList)
            {
                if (item.Lat != 0.0 || item.Lon != 0.0)
                {
                    nonZeroCoordinates.Add(item);
                }
                else
                {
                    zeroCoordinates.Add(item);
                }
            }
            return new Tuple<List<DeviceData>, List<DeviceData>>(nonZeroCoordinates, zeroCoordinates);
        }
    }
}
    

