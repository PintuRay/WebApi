namespace FMS.Db.Entity
{
    public class FinancialYear
    {
        public Guid FinancialYearId { get; set; }
        public string Financial_Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsActive { get; set; } 
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; } 

        //collection Navigation Property
        public ICollection<BranchFinancialYear> BranchFinancialYears { get; set; }
    }
}
