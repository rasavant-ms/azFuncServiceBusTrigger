using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ServiceBusSender
{
    public class CarMessage
    {
        public string CorrelationId { get; set; }
        public string Label { get; set; }
        public int MessageNumber { get; set; }
        public CarDetails CarDetails { get; set; }
        public CarMessage(string correlationId, string label)
        {
            CorrelationId = correlationId;
            Label = label;
            CarDetails = CarDetails;
        }
    }

    public class CarDetails
    {
        public string Location { get; set; }
        public string Color { get; set; }
        public string RandomField { get; set; }

        private List<string> CarColors = new List<string>() { "Red", "Blue", "Green", "Yellow" };
        private List<string> CarLocation = new List<string>() { "Redmond", "Bellevue", "GreenTown", "Yosemite" };
        private List<string> CarRandomField = new List<string>() { "xv", "dfh", "dhrh", "tyfgb" };

        public CarDetails()
        {
            Color = CarColors[new Random().Next(CarColors.Count)];
            Location = CarLocation[new Random().Next(CarLocation.Count)];
            RandomField = CarRandomField[new Random().Next(CarRandomField.Count)];
        }
    }
}
