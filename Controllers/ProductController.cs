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
    }
}
