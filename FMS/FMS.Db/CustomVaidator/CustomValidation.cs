using Microsoft.EntityFrameworkCore;

namespace FMS.Db.CustomVaidator
{
    public class CustomValidation(Context ctx)
    {
        private readonly Context _ctx = ctx;
        public async Task<bool> BeUniqueUsername(string username)
        {
            var resp  =  await _ctx.Users.Where(s=>s.UserName == username).SingleOrDefaultAsync();
            if (resp != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> BeUniqueEmail(string emil)
        {
            var resp = await _ctx.Users.Where(s => s.Email == emil).SingleOrDefaultAsync();
            if (resp != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> BeUniquePhoneNumber(string phoneNumber) {
            var resp = await _ctx.Users.Where(s => s.PhoneNumber == phoneNumber).SingleOrDefaultAsync();
            if (resp != null)
            {
                return true;
            }
            return false;
        }
    }
}
