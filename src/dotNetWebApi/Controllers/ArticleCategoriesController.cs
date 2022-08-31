using dotNetWebApi.Application.Features.ArticleCategories.Commands;
using dotNetWebApi.Application.Features.ArticleCategories.Queries;
using dotNetWebApi.Domain.Entities;
using dotNetWebApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotNetWebApi.Controllers
{
    [ApiController]
    [Route("api/article-categories")]
    public class ArticleCategoriesController : ControllerBase
    {
        private readonly ILogger<ArticleCategoriesController> _logger;

        private readonly IMediator _mediator;

        public ArticleCategoriesController(ILogger<ArticleCategoriesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllArticleCategoriesQuery()); 
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetArticleCategoryByIdQuery(id));

            if (result == null)
                return NotFound();
            
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleCategoryDto articleCategoryDto)
        {
            var result = await _mediator.Send(new CreateArticleCategoryCommand(articleCategoryDto));
            return Ok(result);
        }
    }
}