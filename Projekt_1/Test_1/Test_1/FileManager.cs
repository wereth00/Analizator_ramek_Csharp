using Newtonsoft.Json;
using RAMKI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMKI
{
    internal class FileManager
    {
        string isSorted = "NEW_";
        public void SaveFile(string text, string fileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonFilePath = Path.Combine(desktopPath, isSorted + fileName);

            File.WriteAllText(jsonFilePath, text);
            Console.WriteLine($"Wyniki zostały zapisane do pliku na pulpicie: {jsonFilePath}");
        }

        public List<DeviceData> GetDevicesDataFromFile(string filePath) 
        {
            string fileContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<DeviceData>>(fileContent);
        }
    }
}
