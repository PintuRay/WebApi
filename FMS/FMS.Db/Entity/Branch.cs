namespace FMS.Db.Entity
{
    public class Branch
    {
        public Guid BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string ContactNumber { get; set; }
        public string BranchCode { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; } 
        public DateTime? ModifyDate { get; set; } 
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        //Collection Navigation Property
        public ICollection<UserBranch> UserBranch { get; set; } = [];
        public ICollection<BranchFinancialYear> BranchFinancialYears { get; set; } = [];
        public ICollection<Company> Companies { get; set; } = [];

    }
}
