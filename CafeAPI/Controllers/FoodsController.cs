using CafeAPI.Models;
using CafeAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodRepo _foodRepo;

        public FoodsController(IFoodRepo foodRepo)
        {
            _foodRepo = foodRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Food>> GetBooks()
        {
            return await _foodRepo.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetBooks(int id)
        {
            return await _foodRepo.Get(id);
        }

    }
}
