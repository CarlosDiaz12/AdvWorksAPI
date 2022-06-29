using AdvWorksAPI.DataAccessEF6;
using AdvWorksAPI.DTOs;
using AdvWorksAPI.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdvWorksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _productRepository.GetProducts();
            var result = _mapper.Map<IEnumerable<ProductDTO>>(data);
            return Ok(result);
        }
        [HttpGet("{Id:int}")]
        public IActionResult Get(int Id)
        {
            if (!_productRepository.ProductExists(Id)) return NotFound();

            var product = _productRepository.GetProduct(Id);
            var response = _mapper.Map<ProductDTO>(product);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Create([FromBody] ProductDTO body)
        {
            var product = _mapper.Map<Product>(body);
            _productRepository.AddProduct(product);
            _productRepository.Save();
            return StatusCode(201);
        }
        [HttpDelete("{Id:int}")]
        public IActionResult Delete([FromBody] ProductDTO body)
        {
            if (!_productRepository.ProductExists(body.ProductID)) return NotFound();
            _productRepository.DeleteProduct(new Product { ProductID = body.ProductID });
            _productRepository.Save();
            return Ok();
        }
    }
}
