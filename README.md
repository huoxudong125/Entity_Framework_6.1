Entity_Framework_6.1 
===============
[![Build status](https://ci.appveyor.com/api/projects/status/mu159os1wcfembx0?svg=true)](https://ci.appveyor.com/project/huoxudong125/hqf-tutorial-entityframework-6-1)    


A data access layer class library implemented using Entity Framework 6.1 code first workflow.
 This class library is being developed for use as the data access component of the Prism 5.0 application, which has its own repository.



 ## Partial Update properties using EntityFramework

 https://stackoverflow.com/questions/12871892/entity-framework-validation-with-partial-updates/29689644#29689644

 one way :

 ``` csharp
 using(var dbContext=new DbContext())
 {
	dbContext.Configuration.ValidateOnSaveEnabled = false
 }

 ```
 another way:

 ``` csharp
 protected override DbEntityValidationResult ValidateEntity(
  DbEntityEntry entityEntry,
  IDictionary<object, object> items)
{
  var result = base.ValidateEntity(entityEntry, items);
  var falseErrors = result.ValidationErrors
    .Where(error =>
    {
      if (entityEntry.State != EntityState.Modified) return false;
      var member = entityEntry.Member(error.PropertyName);
      var property = member as DbPropertyEntry;
      if (property != null)
        return !property.IsModified;
      else
        return false;//not false err;
    });

  foreach (var error in falseErrors.ToArray())
    result.ValidationErrors.Remove(error);
  return result;
}

 ```
 
 
 ## Third Resources 
 [EntityFramework-Plus]( https://github.com/zzzprojects/EntityFramework-Plus)  
- Auditing

- Batch Delete
- Batch Update

- LINQ Dynamic

- Query Cache
- Query Deferred
- Query Filter
- Query Future
- Query IncludeFilter
- Query IncludeOptimized
