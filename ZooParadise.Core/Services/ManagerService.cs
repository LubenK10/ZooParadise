using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Core.Contracts;
using ZooParadise.Infrastructure.Data.Common;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Core.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IRepository repository;

        public ManagerService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var user = new Manager()
            {
                UserId = userId,
                Phone = phoneNumber
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> IdExist(string userId)
        {
            return await repository.All<Manager>().AnyAsync(x => x.UserId == userId);
        }
        public async Task<int> TakeManagerId(string userId)
        {
            return (await repository.AllReadonly<Manager>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> UserAdopts(string userId)
        {
            return await repository.All<Pet>()
                .AnyAsync(h => h.AdopterId == userId);
        }

        public async Task<bool> PhoneExist(string phoneNumber)
        {
            return await repository.All<Manager>().AnyAsync(x => x.Phone == phoneNumber);
        }
    }
}
