using dotNetWebApi.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace dotNetWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleCategoriesController : ControllerBase
    {
        private readonly ILogger<ArticleCategoriesController> _logger;
        
        private readonly IWebApiDbContext _context;

        public ArticleCategoriesController(ILogger<ArticleCategoriesController> logger, IWebApiDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = _context.ArticleCategories.ToList();
            return Ok(result);
        }
    }
}