using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Infrastructure.Data;

namespace ZooParadise.Tests.Mock
{
    public static class DatabaseMock
    {
        public static ApplicationDbContext Instance
        {
            get 
            {
                var dataOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase("ZooParadise_InMemory" + DateTime.Now.Ticks.ToString())
                      .Options;

                return new ApplicationDbContext(dataOptions, false);
            }
        }
    }
}
