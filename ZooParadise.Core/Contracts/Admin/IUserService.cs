using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Core.Models.Admin;

namespace ZooParadise.Core.Contracts.Admin
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> All();

    }
}
