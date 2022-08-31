namespace dotNetWebApi.Domain.Entities;

public class Article : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    
    public int ArticleCategoryId { get; set; }
    public virtual ArticleCategory ArticleCategory { get; set; }
}