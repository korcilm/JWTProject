using System.Threading.Tasks;
using JwtProject.Business.Interfaces;
using JWTProject.Entities.Concrete;
using JWTProject.WebApi.CustomFilters;
using JWTProject.Entities.DTOs.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace JWTProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        //api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        //api/products/3
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Add(ProductAddDto product)
        {
            await _productService.Add(_mapper.Map<Product>(product));
            return Created("", product);
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> Update(ProductUpdateDto product)
        {
            await _productService.Update(_mapper.Map<Product>(product));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Remove(new Product() { Id = id });
            return NoContent();
        }
    }
}
