using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using System.Linq;
using ZooParadise.Core.Contracts;
using ZooParadise.Core.Services;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Tests.UnitTests.ManagerServiceTests
{
    [TestFixture]
    public class ManagerServiceTests : UnitTestsBase
    {
        private IManagerService managerService;

        private UserManager<User> userManager;

        [OneTimeSetUp]
        public void SetUp()
            => managerService = new ManagerService(userManager, this.data);

        [Test]
        public void TakeManagerId()
        {
            var result = managerService.TakeManagerId(this.Manager.UserId);

            Assert.AreEqual(1, Manager.Id);
        }

        [Test]
        public void IdExist()
        {
            var result = managerService.IdExist(this.Manager.UserId);

            Assert.IsTrue(result.Result);
        }


        [Test]
        public void PhoneExist()
        {
            var result = managerService.PhoneExist(this.Manager.Phone);

            Assert.IsTrue(true);
        }

        [Test]
        public void Create()
        {
            managerService.Create(Manager.UserId, Manager.Phone);

            var managerCount = data.Managers.Count();

            Assert.AreEqual(1, managerCount);

            var newManagerId = managerService.TakeManagerId(this.Manager.UserId);

            Assert.IsNotNull(newManagerId);
            Assert.AreEqual(this.Manager.Id, newManagerId.Result);
        }


    }
}
