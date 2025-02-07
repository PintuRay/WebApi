namespace FMS.Repo
{
    public class RepoBase
    {
        public RepoBase()
        {
            Id = null;
            Ids = null;
            Records = null;
            Count = 0;
            IsSucess = false;
            ResponseCode = null;
            Message = null;
        }
        public string Id { get; set; } 
        public List<string> Ids { get; set; } = null;
        public object Records { get; set; } = null;
        public int Count { get; set; }
        public bool IsSucess { get; set; }
        public int? ResponseCode { get; set; }
        public string Message { get; set; }
    }
}
