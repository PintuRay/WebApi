namespace FMS.Repo
{
    public class RepoBase
    {
        public string Id { get; set; }
        public List<string> Ids { get; set; } = [];
        public object Records { get; set; } = null;
        public int Count { get; set; }
        public bool IsSucess { get; set; }
        public int ResponseCode { get; set; }
    }
}
