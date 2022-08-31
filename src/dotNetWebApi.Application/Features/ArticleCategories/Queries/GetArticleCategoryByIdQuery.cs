using dotNetWebApi.Application.Contracts;
using dotNetWebApi.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace dotNetWebApi.Application.Features.ArticleCategories.Queries;

public record GetArticleCategoryByIdQuery(int Id) : IRequest<ArticleCategoryDto>;

public class GetArticleCategoryByIdHandler : IRequestHandler<GetArticleCategoryByIdQuery, ArticleCategoryDto>
{
    private readonly IWebApiDbContext _context;

    public GetArticleCategoryByIdHandler(IWebApiDbContext context)
    {
        _context = context;
    }

    public async Task<ArticleCategoryDto> Handle(GetArticleCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ArticleCategories
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result.Adapt<ArticleCategoryDto>();
    }
}