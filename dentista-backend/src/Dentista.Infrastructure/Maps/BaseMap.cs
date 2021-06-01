using Dentista.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dentista.Infrastructure.Maps
{
    public class BaseMap<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : Base
    {
        private readonly string _tableName;

        public BaseMap(string _tableName)
        {
            this._tableName = _tableName;
        }

        public virtual void Configure(EntityTypeBuilder<TDomain> builder)
        {
            if (!string.IsNullOrEmpty(_tableName)) builder.ToTable(_tableName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        }
    }
}