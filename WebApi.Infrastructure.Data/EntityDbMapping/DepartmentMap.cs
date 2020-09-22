using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Data.EntityDbMapping
{
    class DepartmentMap : IEntityTypeConfiguration <Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.DepartmentName)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(150)");

        }

    }
}
