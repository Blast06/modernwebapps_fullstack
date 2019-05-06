using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Repositories;

namespace ModernStore.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/products")]
        public IActionResult Index()
        {
            return Ok(_repository.Get());
        }
    }
}