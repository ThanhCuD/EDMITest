namespace EDMITest.Models
{
    public class Gateways : Devices
    {
        public string IP { get; set; }
        public string Port { get; set; }
    }
    public class CreateGatewaysParamModel : CreateParamModel
    {
        public string IP { get; set; }
        public string Port { get; set; }
    }
    public class UpdateGatewaysParamModel : UpdateParamModel
    {
        public string IP { get; set; }
        public string Port { get; set; }
    }
    public class SearchGatewaysResultModel : SearchResultModel
    {
        public string IP { get; set; }
        public string Port { get; set; }
    }
}
