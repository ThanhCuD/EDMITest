using System;

namespace EDMITest.Models
{
    public class Devices
    {
        public Guid ID { get; set; }
        public string SerialNumber { get; set; }
        // FirmwareVersion
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
    }
    public class CreateParamModel
    {
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
    }
    public class UpdateParamModel: CreateParamModel
    {
        public string Id { get; set; }
    }
    public class SearchResultModel
    {
        public string Id { get; set; }
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
    }
}
