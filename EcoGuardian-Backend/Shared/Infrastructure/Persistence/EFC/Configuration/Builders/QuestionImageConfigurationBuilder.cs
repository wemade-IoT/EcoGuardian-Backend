using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders
{
    public class QuestionImageConfigurationBuilder : IEntityTypeConfiguration<QuestionImage>
    {
        public void Configure(EntityTypeBuilder<QuestionImage> builder)
        {
            builder.HasKey(qi => qi.Id);
            
            builder.Property(qi => qi.Id)
                   .ValueGeneratedOnAdd();
            
            builder.Property(qi => qi.QuestionId)
                   .IsRequired();
            
            builder.Property(qi => qi.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(500);
            
            builder.Property(qi => qi.UploadedAt)
                   .IsRequired();

            // Configurar relación con Question
            builder.HasOne<Question>()
                   .WithMany(q => q.Images)
                   .HasForeignKey(qi => qi.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);
            
            // Configurar nombre de tabla
            builder.ToTable("question_images");
        }
    }
}
