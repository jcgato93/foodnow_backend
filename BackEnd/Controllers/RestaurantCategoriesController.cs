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
    public class RestaurantCategoriesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRestaurantCategoryService restaurantCategoryService;

        public RestaurantCategoriesController(IMapper mapper,
            IRestaurantCategoryService restaurantCategoryService)
        {
            this.mapper = mapper;
            this.restaurantCategoryService = restaurantCategoryService;
        }

        [HttpGet("GetCategoriesByRestaurantId/{restaurantId}")]
        public async Task<ActionResult> GetCategoriesByRestaurantId(int restaurantId, [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 10)
        {
            var resultPaginated = await restaurantCategoryService.GetCategoryByRestaurantId(restaurantId,pageIndex,pageSize);

            Response.Headers["X-Total-Registros"] = resultPaginated.Count.ToString();
            Response.Headers["X-Cantidad-Paginas"] = ((int)Math.Ceiling((double)resultPaginated.Count / resultPaginated.PageSize)).ToString();

            var dto = mapper.Map<List<CategoryDTO>>(resultPaginated.Data);

            return Ok(dto);
        }
    }
}