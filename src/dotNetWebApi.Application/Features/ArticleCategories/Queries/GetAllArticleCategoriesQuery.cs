using dotNetWebApi.Application.Contracts;
using dotNetWebApi.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace dotNetWebApi.Application.Features.ArticleCategories.Queries;

public record GetAllArticleCategoriesQuery : IRequest<IEnumerable<ArticleCategoryDto>>;

public class GetAllArticleCategoriesHandler : IRequestHandler<GetAllArticleCategoriesQuery, IEnumerable<ArticleCategoryDto>>
{
    private readonly IWebApiDbContext _context;

    public GetAllArticleCategoriesHandler(IWebApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ArticleCategoryDto>> Handle(GetAllArticleCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ArticleCategories
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);

        return result.Adapt<IEnumerable<ArticleCategoryDto>>();
    }
}