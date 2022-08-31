using Mapster;

namespace dotNetWebApi.Domain.Entities;

[AdaptTo("[name]Dto"), GenerateMapper]
public class ArticleCategory : BaseEntity
{

    public string Name { get; set; }
    public string Description { get; set; }
    
    public ICollection<Article> Articles { get; set; }
}