using dotNetWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace dotNetWebApi.Persistence.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.Property(e => e.Title).HasMaxLength(300);

        builder.HasOne(p => p.ArticleCategory)
            .WithMany(d => d.Articles)
            .HasForeignKey(p => p.ArticleCategoryId);
    }
}