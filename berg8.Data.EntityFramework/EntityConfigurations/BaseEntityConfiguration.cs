//using System.Data.Entity.ModelConfiguration;
using Berg8.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Berg8.Data.EntityFramework.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        protected BaseEntityConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.DateCreated)
                .IsRequired();

            Property(x => x.DateLastModified)
                .IsOptional();
        }

        public void Configure(EntityTypeBuilder<T> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
