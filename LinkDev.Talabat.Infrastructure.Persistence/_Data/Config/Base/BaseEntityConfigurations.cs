using LinkDev.Talabat.Core.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data.Config.Base
{
    internal class BaseEntityConfigurations<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
     where TEntity : BaseEntity<TKey> // TEntity must be a subclass of BaseEntity with TKey
     where TKey : IEquatable<TKey>    // TKey must implement IEquatable
    {   public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {

            builder.Property(E => E.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(E => E.CreatedBy).IsRequired();
            builder.Property(E => E.CreatedOn).IsRequired();/*.HasDefaultValueSql("GETUTCDATE()");*/

            builder.Property(E => E.LastModifiedBy).IsRequired();
            builder.Property(E => E.LastModifiedOn).IsRequired();/*.HasDefaultValueSql("GETUTCDATE()");*/

        }

      
    }
}
