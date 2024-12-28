namespace FMS.Repo
{
    public class RepoBase
    {
        public string Id { get; set; }
        public List<string> Ids { get; set; } = [];
        public List<string> Data { get; set; } = [];
        public string Count { get; set; }
        public bool IsSucess { get; set; }
     
    }
}
