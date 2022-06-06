using ApiUsuario.Domain.Entities;
using ApiUsuario.Domain.ValeuObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiUsuario.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("Id");

            builder.Property(u => u.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .HasMaxLength(200)
                .HasConversion(c => (string)c, c =>(Email)c)
                .IsRequired();

            builder.Property(u => u.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(u => u.Scholarity)
                .HasColumnName("Scholarity")
                .HasMaxLength(50)
                .HasConversion(c => (string)c, c => (Scholarity)c)
                .IsRequired();


        }
    }
}
