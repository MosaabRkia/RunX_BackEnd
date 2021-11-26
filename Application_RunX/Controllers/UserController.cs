using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application_RunX.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("api/User/getUsers")]
        public void getUsers()
        {
            Console.WriteLine("worked");
        }
    }
}