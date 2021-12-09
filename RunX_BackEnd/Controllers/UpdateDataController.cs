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

        [HttpPost]
        [Route("updateWeight")]
        public IActionResult updateWeight([FromBody] Weight weight)
        {
            //get id = 0 always and get userid and null time
            bool checker = _updateService.weightUpdate(weight);
            if (checker) return Ok(true);
            else return BadRequest(false);
        }

        [HttpPost]
        [Route("update24dailySteps")]
        public IActionResult update24dailySteps([FromBody] Steps steps)
        {
            //get id = 0 always and get userid and null time
            bool checker = _updateService.stepsUpdate(steps);
            if (checker) return Ok(true);
            else return BadRequest(false);
        }
        [HttpPost]
        [Route("update24dailyWaterCups")]
        public IActionResult update24dailyWaterCups([FromBody] CupsOfWater cupsofwater)
        {
            //get id = 0 always and get userid and null time
            bool checker = _updateService.cupsOfWaterUpdate(cupsofwater);
            if (checker) return Ok(true);
            else return BadRequest(false);
        }
        [HttpPost]
        [Route("update24Sleeps")]
        public IActionResult update24Sleeps([FromBody] Sleep sleep)
        {
            //get id = 0 always and get userid and null time
            bool checker = _updateService.sleepsUpdate(sleep);
            if (checker) return Ok(true);
            else return BadRequest(false);
        }
        [HttpPost]
        [Route("update24KcalDaily")]
        public IActionResult update24KcalDaily([FromBody] KCal kcal)
        {
            //get id = 0 always and get userid and null time
            bool checker = _updateService.kCalUpdate(kcal);
            if (checker) return Ok(true);
            else return BadRequest(false);
        }
        [HttpPost]
        [Route("update24meals")]
        public IActionResult update24meals([FromBody] List<Meal> mealList)
        {
            //get id = 0 always and get userid and null time
            bool checker = true;
            mealList.ForEach(e => {
                if (e != null)
                {
                    if (_updateService.mealsUpdate(e) == false)
                        checker = false;
                }
                else
                {
                    checker = false;
                }
            });

            if (checker) return Ok(true);
            else return BadRequest(false);
        }
        //ChoosenFood
        [HttpGet]
        [Route("getChoosenFood/{id}")]
        public IActionResult test1(int id)
        {
            return Ok(_updateService.ChoosenFoodGetter(id));
        }

        //updateSteps
        [HttpGet]
        [Route("updateSteps/{steps}/{stepsId}")]
        public IActionResult updateSteps(int steps,int stepsId)
        {
            return Ok(_updateService.updateSteps(steps,stepsId));
        }

        //updateSleeps
        [HttpGet]
        [Route("updateSleeps/{sleepTime}/{sleepId}")]
        public IActionResult updateSleeps(double sleepTime, int sleepId)
        {
            return Ok(_updateService.updateSleep(sleepTime, sleepId));
        }
    }
}
