using Microsoft.AspNetCore.Identity;

namespace FMS.Db.Entity
{
    public class AppUser : IdentityUser
    {
        public Guid FkTokenId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        //Reference Navigation Property
        public RegisterToken Token { get; set; }
        //collection Navigation Property
        public ICollection<UserBranch> UserBranch { get; set; }
    }
}
