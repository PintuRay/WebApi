﻿namespace FMS.Repo
{
    public class RepoBase
    {
        public string Id { get; set; }
        public List<string> Ids { get; set; } = new List<string>();
        public string Count { get; set; }
        public bool IsSucess { get; set; }
     
    }
}
