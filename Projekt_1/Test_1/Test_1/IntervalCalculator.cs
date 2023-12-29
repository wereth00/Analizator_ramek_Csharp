using RAMKI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMKI
{
    internal class IntervalCalculator
    {
        public List<DeviceData> Calculate(List<DeviceData> inputs)
        {
            var buffer = new List<KeyValuePair<int, DeviceData>>();
            var result = new List<DeviceData>();
            int i = 0;

            foreach (var input in inputs)
            {
                if (buffer.Any() && buffer.Last().Value.Slot1.WorkState != input.Slot1.WorkState)
                {
                    i++;
                }

                buffer.Add(new KeyValuePair<int, DeviceData>(i, input));
            }

            foreach (var group in buffer.GroupBy(x => x.Key))
            {
                var first = group.Select(x => x.Value).First();
                var last = group.Select(x => x.Value).Last();

                result.Add(first);

                if (last != first)
                {
                    result.Add(last);
                }
            }

            return result;
        }
    }
}
