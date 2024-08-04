namespace FMS.Db.Entity
{
    public class BranchFinancialYear
    {
        public Guid BranchFinancialYearId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public bool? IsActive { get; set; } 
        public DateTime? CreatedDate { get; set; } 
        public DateTime? ModifyDate { get; set; } 
        public string CreatedBy { get; set; } 
        public string ModifyBy { get; set; } 

        //Reference Navigation Property
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
}
