using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Db.Entity
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public string CompanyName { get; set; }
        public string State { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string GSTIN { get; set; }
        public string Logo { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public Branch Branch { get; set; }
    }
}
