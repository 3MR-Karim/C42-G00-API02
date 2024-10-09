using LinkDev.Talabat.Core.Application.Abstraction;
using LinkDev.Talabat.Core.Domain.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Persistence.Interception
{
    internal class CustomSaveChangesInterceptor : ISaveChangesInterceptor
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public CustomSaveChangesInterceptor(ILoggedInUserService LoggedInUserService)
        {
            _loggedInUserService = LoggedInUserService;
        }




        public override InterceptionResult<int> SavingChanges(DbContextErrorEventData eventData,Interception result)
        {
            UpdateEntities(eventData.Context);
            return base.SavedChangesAsync(eventData, result,CancellationToken);
        }




        public ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
           
            return new ValueTask<int>(result);
        }

        private void UpdateEntities(DbContext? dbContext) {



            foreach (var entry in dbContext.ChangeTracker.Entries<BaseAuditableEntity<int>>().Where(entity => entity.State is EntityState.Added or EntityState.Modified))
            {
                if (dbContext is null)
                    return;

                if (entry.State is EntityState.Added or EntityState.Modified)
                {

                    entry.Entity.CreatedBy = _loggedInUserService.UserId! ??"";
                    entry.Entity.CreatedOn = DateTime.Now;
                }
                entry.Entity.LastModifiedBy = _loggedInUserService.UserId!;
                entry.Entity.LastModifiedOn = DateTime.Now;
            }

















        }


    }
}
