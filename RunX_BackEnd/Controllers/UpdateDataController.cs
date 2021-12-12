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
            try
            {
           bool checker = _updateService.UpdateWaterCups(type == "plus" ? 1 : -1, id);
            if (checker) return Ok(true);
            else return Ok(false);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("updateEatenFood/{mealId}/{kCalId}")]
        public IActionResult updateEatenFood( int mealId,int kCalId)
        {
            try
            {
            double checker = _updateService.UpdateEatenFood(mealId,kCalId);
            if (checker != -1) return Ok(checker);
            else return Ok(checker);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("addMedicine")]
        public IActionResult addMedicine([FromBody]Medicine med)
        {
            try
            {
            bool checker = _updateService.addMedicine(med);
            if (checker) return Ok(true);
            else return Ok(false);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
       

        [HttpGet]
        [Route("removeMedicine/{id}")]
        public IActionResult removeMedicine(int id)
        {
            try
            {
            bool checker = _updateService.removeMedicine(id);
            if (checker) return Ok(true);
            else return Ok(false);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("updateWeight")]
        public IActionResult updateWeight([FromBody] Weight weight)
        {
            try
            {
            //get id = 0 always and get userid and null time
            bool checker = _updateService.weightUpdate(weight);
            if (checker) return Ok(true);
            else return Ok(false);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("update24dailySteps")]
        public IActionResult update24dailySteps([FromBody] Steps steps)
        {
            try
            {
            bool checker = _updateService.stepsUpdate(steps);
            if (checker) return Ok(true);
            else return Ok(false);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            //get id = 0 always and get userid and null time
        }
        [HttpPost]
        [Route("update24dailyWaterCups")]
        public IActionResult update24dailyWaterCups([FromBody] CupsOfWater cupsofwater)
        {
            try
            {
            //get id = 0 always and get userid and null time
            bool checker = _updateService.cupsOfWaterUpdate(cupsofwater);
            if (checker) return Ok(true);
            else return Ok(false);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("update24Sleeps")]
        public IActionResult update24Sleeps([FromBody] Sleep sleep)
        {
            try
            {
            //get id = 0 always and get userid and null time
            bool checker = _updateService.sleepsUpdate(sleep);
            if (checker) return Ok(true);
            else return Ok(false);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("update24KcalDaily")]
        public IActionResult update24KcalDaily([FromBody] KCal kcal)
        {
            try
            {
            //get id = 0 always and get userid and null time
            bool checker = _updateService.kCalUpdate(kcal);
            if (checker) return Ok(true);
            else return Ok(false);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("update24meals")]
        public IActionResult update24meals([FromBody] List<Meal> mealList)
        {
            try
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
            else return Ok(false);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        //ChoosenFood
        [HttpGet]
        [Route("getChoosenFood/{id}")]
        public IActionResult getfoodChossen(int id)
        {
            try
            {
            return Ok(_updateService.ChoosenFoodGetter(id));

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //updateSteps
        [HttpGet]
        [Route("updateSteps/{steps}/{stepsId}")]
        public IActionResult updateSteps(int steps,int stepsId)
        {
            try
            {
            return Ok(_updateService.updateSteps(steps,stepsId));

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //updateSleeps
        [HttpGet]
        [Route("updateSleeps/{sleepTime}/{sleepId}")]
        public IActionResult updateSleeps(double sleepTime, int sleepId)
        {
            try
            {
            return Ok(_updateService.updateSleep(sleepTime, sleepId));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
