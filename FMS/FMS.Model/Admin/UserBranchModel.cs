using FMS.Model.Devloper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Model.Admin
{
    public class UserBranchModel
    {
        public Guid Id { get; set; }
        public string Fk_UserId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        //Navigation Property

        public BranchModel Branch { get; set; } = new();
    }
}
