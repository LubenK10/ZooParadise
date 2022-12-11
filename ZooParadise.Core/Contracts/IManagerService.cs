using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Core.Contracts
{
    public interface IManagerService
    {
        Task<bool> IdExist(string userId);

        Task<bool> PhoneExist(string phoneNumber);

        Task<int> TakeManagerId(string userId);

        Task<bool> UserAdopts(string userId);
        

        Task Create(string userId, string phoneNumber);
    }
}
