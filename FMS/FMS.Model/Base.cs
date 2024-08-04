namespace FMS.Model
{
    public class Base
    {
        public string Count { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int ResponseCode { get; set; }
    }
    public class BaseDb
    {
        public string Id { get; set; }
        public string Count { get; set; }
        public bool IsSucess { get; set; }

    }
}
