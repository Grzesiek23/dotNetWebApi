using dotNetWebApi.Application.Contracts;
using dotNetWebApi.Domain.Entities;
using dotNetWebApi.Domain.Models;
using Mapster;
using MediatR;

namespace dotNetWebApi.Application.Features.ArticleCategories.Commands;

public record CreateArticleCategoryCommand(ArticleCategoryDto ArticleCategoryDto) : IRequest<int>;

public class CreateArticleCategoryHandler : IRequestHandler<CreateArticleCategoryCommand, int>
{
    private readonly IWebApiDbContext _context;
    
    public CreateArticleCategoryHandler(IWebApiDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateArticleCategoryCommand request, CancellationToken cancellationToken)
    {
        var articleCategory = request.ArticleCategoryDto.Adapt<ArticleCategory>();

        await _context.ArticleCategories.AddAsync(articleCategory, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return articleCategory.Id;
    }
}