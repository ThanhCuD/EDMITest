using System;
using System.ComponentModel.DataAnnotations;

namespace EDMITest.Entity
{
    public class Devices
    {
        public int ID { get; set; }
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
    }
}
