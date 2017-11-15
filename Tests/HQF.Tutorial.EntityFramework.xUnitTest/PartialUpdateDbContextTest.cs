using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQF.Tutorial.EntityFramework.Commons.DbContexts;
using HQF.Tutorial.EntityFramework.Commons.Entities;
using Xunit;
using Xunit.Abstractions;

namespace HQF.Tutorial.EntityFramework.xUnitTest
{
    public class PartialUpdateDbContextTest : TestBase
    {
        private readonly ITestOutputHelper _outputHelper;

        public PartialUpdateDbContextTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void TestPartialUpdate()
        {
            using (var dbContext = new PartialUpdateDbContext())
            {
              //部分更新
                var user = new User {UserId = 1,
                    FirstName = "First Name Changed",
                    LastName = "Last Name Changed"};

                dbContext.Set<User>().Attach(user);
                DbEntityEntry<User> entry = dbContext.Entry(user);
                entry.State = EntityState.Unchanged;
                entry.Property(t => t.LastName).IsModified = true;
                dbContext.SaveChanges();
            }


            using (var dbContext = new PartialUpdateDbContext())
            {
                var user = dbContext.Users.Find(1);
                Assert.NotNull(user);

                _outputHelper.WriteLine("UserId [{0}],FirstName[{1}],LastName[{2}]", 
                    user.UserId, 
                    user.FirstName,
                    user.LastName);
            }
        }
    }
}