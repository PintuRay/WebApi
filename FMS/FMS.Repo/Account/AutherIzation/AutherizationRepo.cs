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

    }
}
