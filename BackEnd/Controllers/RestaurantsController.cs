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
    public class RestaurantsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRestaurantService restaurantService;

        public RestaurantsController(IMapper mapper,
            IRestaurantService restaurantService)
        {
            this.mapper = mapper;
            this.restaurantService = restaurantService;
        }


        [HttpGet("GetAll")]
        public ActionResult GetAll([FromQuery]int pageIndex=0,[FromQuery]int pageSize=10)
        {
            var resultPaginated = restaurantService.GetAll((int)pageIndex,(int)pageSize);            

            Response.Headers["X-Total-Registros"] = resultPaginated.Count.ToString();            
            Response.Headers["X-Cantidad-Paginas"] = ((int)Math.Ceiling((double)resultPaginated.Count / resultPaginated.PageSize)).ToString();

            var dto = mapper.Map<List<RestaurantDTO>>(resultPaginated.Data);

            return Ok(dto);            
        }
    }
}