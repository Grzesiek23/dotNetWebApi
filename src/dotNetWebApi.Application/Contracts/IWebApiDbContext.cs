using dotNetWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotNetWebApi.Application.Contracts;

public interface IWebApiDbContext
{
    DbSet<ArticleCategory> ArticleCategories { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}