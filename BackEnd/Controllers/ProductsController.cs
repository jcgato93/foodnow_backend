using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd.DTOs;
using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductService productService;

        public ProductsController(IMapper mapper,
            IProductService productService)
        {
            this.mapper = mapper;
            this.productService = productService;
        }


        [HttpGet("GetProductsByCategoryId/{categoryId}")]       
        public async Task<ActionResult> GetCategoriesByRestaurantId(int categoryId, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 10)
        {
            var resultPaginated = await productService.GetProductsByCategoryId(categoryId, pageIndex, pageSize);

            Response.Headers["X-Total-Registros"] = resultPaginated.Count.ToString();
            Response.Headers["X-Cantidad-Paginas"] = ((int)Math.Ceiling((double)resultPaginated.Count / resultPaginated.PageSize)).ToString();

            var dto = mapper.Map<List<ProductDTO>>(resultPaginated.Data);

            return Ok(dto);
        }
    }
}