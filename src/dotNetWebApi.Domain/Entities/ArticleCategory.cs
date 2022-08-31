namespace dotNetWebApi.Domain.Entities;

public class ArticleCategory : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public virtual ICollection<Article> Articles { get; set; }
}