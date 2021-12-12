using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.models;
using DataAccess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunX_BackEnd.JWT;
using RunX_BackEnd.Models;

namespace RunX_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly UserService _userService;
        private readonly IJwtTokenManager _tokenManager;

        public UserController(UserService userService,IJwtTokenManager jwtTokenManager)
        {

            _userService = userService;
            _tokenManager = jwtTokenManager;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
            bool Sucessfully = _userService.CreateUser(user);

            return Ok(Sucessfully);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("changePasswordVerify")]
        public IActionResult changePassword([FromBody] resetPassword data)
        {
            try
            {
            bool Sucessfully = _userService.changepassword(_tokenManager.DeCode(data.token),data.password);

            return Ok(Sucessfully);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

     
        [HttpGet]
        [Route("checkEmail/{email}")]
        public IActionResult changePassword(string email)
        {
            try
            {
         bool Sucessfully = _userService.checkEmail(email);

                    return Ok(Sucessfully);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }



    }
}
