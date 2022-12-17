using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Core.Contracts;
using ZooParadise.Infrastructure.Data;
using ZooParadise.Infrastructure.Data.Common;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Core.Services
{
    public class ManagerService : IManagerService
    {

        private readonly ApplicationDbContext data;

        private readonly UserManager<User> userManager;

        public ManagerService(
            UserManager<User> _userManager,
            ApplicationDbContext _data)
        {
            userManager = _userManager;
            data = _data;
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var manager = new Manager()
            {
                UserId = userId,
                Phone = phoneNumber
            };

            var user = data.Users.First(x => x.Id == userId);

            await userManager.RemoveFromRoleAsync(user, "User");
            await userManager.AddToRoleAsync(user, "Administrator");

            await data.Managers.AddAsync(manager);
            await data.SaveChangesAsync();
        }

        public async Task<bool> IdExist(string userId)
        {
            return await data.Managers.AnyAsync(x => x.UserId == userId);
        }
        public async Task<int> TakeManagerId(string userId)
        {
            return (await data.Managers
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> UserAdopts(string userId)
        {
            return await data.Pets
                .AnyAsync(h => h.AdopterId == userId);
        }

        public async Task<bool> PhoneExist(string phoneNumber)
        {
            return await data.Managers.AnyAsync(x => x.Phone == phoneNumber);
        }
    }
}
