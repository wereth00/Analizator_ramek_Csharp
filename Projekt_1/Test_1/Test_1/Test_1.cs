using RAMKI.Models;
using RAMKI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlTypes;

namespace Test_1
{
    public partial class Form1 : Form
    {
        private bool isFileSelected = false; // Zmienna przechowująca informację o wybranym pliku
        private string filePath = string.Empty;
        private string fileName = string.Empty;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            var fileManager = new FileManager();

            if (!isFileSelected) // Sprawdzamy, czy plik nie został jeszcze wybrany
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    FilePathTextBox.Text = selectedFilePath;

                    filePath = selectedFilePath;
                    fileName = Path.GetFileNameWithoutExtension(filePath);

                    isFileSelected = true; // Oznaczamy, że plik został wybrany
                }
            }
        }

        private void InfoTextBox_TextChanged(object sender, EventArgs e)
        {
        }

     

        private void UpdateInfoTextBox(string message)
        {
            if (InfoTextBox.InvokeRequired)
            {
                InfoTextBox.Invoke(new Action(() => InfoTextBox.Text = message));
            }
            else
            {
                InfoTextBox.Text = message;
            }
        }

        private void convertFileButton_Click(object sender, EventArgs e)
        {           
                var deviceDataProcessor = new DeviceDataProcessor();
                var intervalCalculator = new IntervalCalculator();
                var fileManager = new FileManager();

                UpdateInfoTextBox("Pliki są w trakcie obróbki..."); // Ustaw informację w InfoTextBox

               
                    var deviceDataList = fileManager.GetDevicesDataFromFile(filePath);
                    var result = intervalCalculator.Calculate(deviceDataList);
                    var deviceDataListWithIntervals = intervalCalculator.Calculate(deviceDataList);

                    try
                    {
                        string jsonResult = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);                        
                        var listWithDate = deviceDataListWithIntervals.Select(x => new DeviceDataDate(x));
                        jsonResult = JsonConvert.SerializeObject(listWithDate, Newtonsoft.Json.Formatting.Indented);                        
                    
                        fileManager.SaveFile(jsonResult, fileName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Blad podczas zapisu wyników do pliku: {ex.Message}");
                    }
                           
                     UpdateInfoTextBox("Obróbka plików zakończona."); // Aktualizacja informacji w InfoTextBox po zakończeniu obróbki            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
