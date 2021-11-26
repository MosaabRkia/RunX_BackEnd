using DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunX_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        readonly ItemsService _itemsService;

        public ItemsController(ItemsService itemsService)
        {
            _itemsService = itemsService;
        }
        /*[Route("get_All_FoodItems")]*/

        //get all food items
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_itemsService.Get());

        }

        // get food item by id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_itemsService.Get(id));

        }

      /*  [HttpGet]
        [Route("setItems")]
        public IActionResult setItems()
        {
            return Ok(_itemsService.addItems());
        }*/

       

    }
}
