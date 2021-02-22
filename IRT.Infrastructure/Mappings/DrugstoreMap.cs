using IRT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRT.Infrastructure.Mappings
{
    public class DrugstoreMap : IEntityTypeConfiguration<Drugstore>
    {
        public void Configure(EntityTypeBuilder<Drugstore> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(c => c.Neighborhood)
                .WithMany(c => c.Drugstores)
                .HasForeignKey(c => c.NeighborhoodId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
                   
        }
    }
}
