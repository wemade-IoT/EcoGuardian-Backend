using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;



namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders
{
    public class QuestionConfigurationBuilder : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");

            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id)
                .ValueGeneratedOnAdd();

            builder.Property(q => q.Content)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(q => q.CreatedAt)
                .IsRequired();

            builder.Property(q => q.UpdatedAt)
                .IsRequired();

            builder.Property(q => q.State)
                .IsRequired()
                .HasConversion<string>();


            /*
                       builder.HasOne(q => q.User)
                           .WithMany(u => u.Questions)
                           .HasForeignKey(q => q.UserId)
                           .OnDelete(DeleteBehavior.Cascade);

           Agregar cuando ya este User agregado
           */
            builder.HasIndex(q => q.UserId);

            builder.HasOne<Plant>()
                .WithMany()
                .HasForeignKey(q => q.PlantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}