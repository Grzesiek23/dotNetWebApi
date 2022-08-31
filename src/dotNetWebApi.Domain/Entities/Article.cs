using Mapster;

namespace dotNetWebApi.Domain.Entities;

[AdaptTo("[name]Dto"), GenerateMapper]
public class Article : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    
    public int ArticleCategoryId { get; set; }
    public ArticleCategory ArticleCategory { get; set; }
}