using System.Reflection;
using dotNetWebApi.Application.Contracts;
using dotNetWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotNetWebApi.Persistence.Contexts;

public class WebApiDbContext : DbContext, IWebApiDbContext
{
    public WebApiDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ArticleCategory> ArticleCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebApiDbContext).Assembly);
    }
}