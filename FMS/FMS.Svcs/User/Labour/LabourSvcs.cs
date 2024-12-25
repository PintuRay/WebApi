using FMS.Db.Entity;
using FMS.Repo.User.Labour;
using FMS.Svcs.Email;

namespace FMS.Svcs.User.Labour
{
    public class LabourSvcs(ILabourRepo labourRepo, IEmailSvcs emailSvc) : ILabourSvcs
    {
        #region Dependancy
        private readonly ILabourRepo _labourRepo = labourRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Labour Details
        #region Crud
        public async Task<SvcsBase> GetAllLabourTypes()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> GetAllLabourDetails()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateLabourDetail(LabourModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateLabourDetail(Guid Id, LabourModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveLabourDetail(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedLabourDetails()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverLabourDetails(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteLabourDetails(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllLabourDetails(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllLabourDetails(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
