using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Core.Contracts.Admin;
using ZooParadise.Core.Models.Admin;
using ZooParadise.Infrastructure.Data;
using ZooParadise.Infrastructure.Data.Common;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Core.Services.Admin
{
    public class UserService : IUserService
    {

        private readonly UserManager<User> userManager;

        private readonly ApplicationDbContext data;


        public UserService(
            ApplicationDbContext _data,
            UserManager<User> _userManager)
        {
            data = _data;
            userManager = _userManager;
        }


        public async Task<IEnumerable<UserModel>> All()
        {
            List<UserModel> result;

            result = await data.Managers
                .Where(a => a.User.IsActive)
                .Select(a => new UserModel()
                {
                    UserId = a.UserId,
                    Email = a.User.Email,
                    FullName = $"{ a.User.FirstName } { a.User.LastName }",
                    PhoneNumber = a.Phone
                })
                .ToListAsync();

            string[] managerIds = result.Select(a => a.UserId).ToArray();

            result.AddRange(await data.Users
                .Where(u => managerIds.Contains(u.Id) == false)
                .Where(u => u.IsActive)
                .Select(u => new UserModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    FullName = $"{ u.FirstName } { u.LastName }"
                }).ToListAsync());

            return result;
        }

       
    }
}
