using System.ComponentModel.DataAnnotations;
namespace FMS.Model.Account.Autherization
{
    public class RoleModel
    {
        [Required]
        public string Name { get; set; }
    }
    public class RoleDbModel : RoleModel
    {
        public string Id { get; set; }
        public List<UserRoleModel> Users { get; set; }
    }
}
