using FMS.Db.Entity;
using FMS.Model.Devloper;

namespace FMS.Model.Admin
{
    public class CompanyModel
    {   
        public Guid Fk_BranchId { get; set; }
        public string CompanyName { get; set; }
        public string State { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string GSTIN { get; set; }
        public string Logo { get; set; }
    }
    public class CompanyViewModel: CompanyModel
    {
        public string CompanyId { get; set; }
        public Branch Branch { get; set; }
    }
}
