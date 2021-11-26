using Microsoft.AspNetCore.Mvc;
using System;
using DataAccess.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.models;

namespace RunX_BackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UpdateDataController : ControllerBase
    {
        readonly UpdateService _updateService;

        public UpdateDataController(UpdateService updateService)
        {
            _updateService = updateService;
        }

        [HttpGet]
        [Route("updateCupsWater/{type}/{id}")]
        public IActionResult updateCupsWater(string type,int id)
        {
           bool checker = _updateService.UpdateWaterCups(type == "plus" ? 1 : -1, id);
            if (checker) return Ok(true);
            else return BadRequest(false);
        }

        [HttpGet]
        [Route("updateEatenFood/{mealId}/{kCalId}")]
        public IActionResult updateEatenFood( int mealId,int kCalId)
        {
            double checker = _updateService.UpdateEatenFood(mealId,kCalId);
            if (checker != -1) return Ok(checker);
            else return BadRequest(checker);
        }

        [HttpPost]
        [Route("addMedicine")]
        public IActionResult addMedicine([FromBody]Medicine med)
        {
            bool checker = _updateService.addMedicine(med);
            if (checker) return Ok(true);
            else return BadRequest(false);
        }
       

        [HttpGet]
        [Route("removeMedicine/{id}")]
        public IActionResult removeMedicine(int id)
        {
            bool checker = _updateService.removeMedicine(id);
            if (checker) return Ok(true);
            else return BadRequest(false);
        }

    }
}
