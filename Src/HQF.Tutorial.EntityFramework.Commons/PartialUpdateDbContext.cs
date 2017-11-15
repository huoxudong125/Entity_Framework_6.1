using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQF.Tutorial.EntityFramework.Commons.DbContexts.Mappings;
using HQF.Tutorial.EntityFramework.Commons.Entities;

namespace HQF.Tutorial.EntityFramework.Commons.DbContexts
{
    public class PartialUpdateDbContext:DbContext
    {
        public PartialUpdateDbContext()
        {
            Database.SetInitializer(new PartialUpdateDbContextInitializer());
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var result = base.ValidateEntity(entityEntry, items);

            var falseErrors = result.ValidationErrors
                .Where(error =>
                {
                    if (entityEntry.State != EntityState.Modified) return false;
                    var member = entityEntry.Member(error.PropertyName);
                    var property = member as DbPropertyEntry;
                    if (property != null) return !property.IsModified;
                    return false;
                });

            foreach (var error in falseErrors.ToArray())
            {
                result.ValidationErrors.Remove(error);
            }

            return result;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserMap());
        }

        public DbSet<User> Users { get; set; }

    }
}
