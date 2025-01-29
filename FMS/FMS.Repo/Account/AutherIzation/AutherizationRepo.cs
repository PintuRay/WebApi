using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Account.Authentication;
using FMS.Model.Account.Autherization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace FMS.Repo.Account.AutherIzation
{
    public class AutherizationRepo(Context ctx) : IAutherizationRepo
    {
        private readonly Context _ctx = ctx;

        public async Task<Result<UserDto>> GetUserById(string Id)
        {
            Result<UserDto> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Users
                      .Select(s => new UserDto()
                      {
                          Id = s.Id,
                          Name = s.Name,
                          Email = s.Email,
                          BirthDate = s.BirthDate,
                          MaratialStatus = s.MaratialStatus,
                          Gender = s.Gender,
                          PhotoPath = s.PhotoPath,
                          PhoneNumber = s.PhoneNumber,
                          Address = new AddressDto()
                          {
                              AddressId = s.Address.AddressId,
                              At = s.Address.At,
                              City = s.Address.City,
                              PinCode = s.Address.PinCode,
                              Post = s.Address.Post,
                              Fk_DistId = s.Address.Fk_DistId,
                              Fk_StateId = s.Address.Fk_StateId,
                              Fk_CountryId = s.Address.Fk_CountryId,
                          },
                      }).SingleOrDefaultAsync(s => s.Id == Id);
                if (Query != null)
                {
                    _Result.SingleObjData = Query;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
    }
}
