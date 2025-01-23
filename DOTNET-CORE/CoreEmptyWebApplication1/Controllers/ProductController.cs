using CoreEmptyWebApplication1.Interfaces;
using CoreEmptyWebApplication1.Models;
using CoreEmptyWebApplication1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CoreEmptyWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly ProductRepository _productRepository;
        private readonly IProductInterface _productRepository;
        private readonly IProductInterface _productRepository2;


        // the asp.net core framework sees what things are required by looking in the constructor and then provides appropriate items.
        // it checks whether that service is registered. if yes, it created instance of the repository and injects into the controller.
        public ProductController(IProductInterface productRepository, IProductInterface productRepository2)
        {
            // everytime new instance of this will be created whenever any endpoint is hit.
            // Thus use singleton, scoped or transient servicess.
            //_productRepository = new ProductRepository();

            // dependency can be created either by constructor, method or property.
            _productRepository = productRepository; // (controller doesn't know anything about implementation as product repository is not visible.)
            _productRepository2 = productRepository2;

        }

        [HttpPost("add")]
        public IActionResult AddProduct([FromBody] ProductModel product)
        {
            _productRepository.AddProduct(product);
            var products = _productRepository2.GetAll();  // note that interface instance is different here.
            return Ok(products);
        }
    }
}
