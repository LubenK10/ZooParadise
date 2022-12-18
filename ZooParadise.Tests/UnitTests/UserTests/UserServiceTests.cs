using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Core.Contracts.Admin;
using ZooParadise.Core.Services.Admin;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Tests.UnitTests.UserTests
{
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService userService;
        private UserManager<User> userManager;

        [OneTimeSetUp]
        public void SetUp() => userService = new UserService(data, userManager);

        [Test]
        public void All_ShouldReturnAllUsersAndManagers()
        {
            var result = userService.All();

            Assert.IsNotNull(result);

       
        }
    }
}
