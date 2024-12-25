﻿using FMS.Db.Entity;

namespace FMS.Repo.User.Labour
{
    public class LabourRepo: ILabourRepo
    {
        #region labour Details    
        #region Crud
        public async Task<RepoBase> GetAllLabourTypes() { throw new NotImplementedException(); }
        public async Task<Result<Db.Entity.Labour>> GetAllLabourDetails() { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateLabourDetail(LabourModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateLabourDetail(Guid Id, LabourModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveLabourDetail(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<Db.Entity.Labour>> GetRemovedLabourDetails() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverLabourDetails(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteLabourDetails(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllLabourDetails(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllLabourDetails(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
