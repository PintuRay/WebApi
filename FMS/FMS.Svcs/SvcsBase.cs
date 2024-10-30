namespace FMS.Svcs
{
    public class SvcsBase
    {
        public string Count { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int ResponseCode { get; set; }
    }
}
