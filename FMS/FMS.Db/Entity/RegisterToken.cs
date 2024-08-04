namespace FMS.Db.Entity
{
    public class RegisterToken
    {
        public Guid TokenId { get; set; }
        public string TokenValue { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        //Reference Navigation Property
        public AppUser User { get; set; }

    }
}
