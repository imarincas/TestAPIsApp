namespace SOAPApi
{
    public class SoapRequest
    {
        public string EndPoint { get; set; }
        public string XmlData { get; set; }
        public Headers Header { get; set; }
    }
}
