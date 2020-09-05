namespace EDMITest.Models
{
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
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
    }
}
