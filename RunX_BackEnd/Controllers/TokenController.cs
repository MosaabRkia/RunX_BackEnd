using DataAccess.models;
using DataAccess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunX_BackEnd.JWT;
using RunX_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RunX_BackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJwtTokenManager _tokenManager;
        private readonly UserService _userService;

      
        public TokenController(IJwtTokenManager jwtTokenManager,UserService userService)
        {
            _tokenManager = jwtTokenManager;
            _userService = userService;
        }  

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate([FromBody] userCredntial user)
        {
            if (user.email == null || user.password == null)
                return Ok(false);

            bool found =  _userService.checkLogin(user.email, user.password);
            if (found)
            {
             var token = _tokenManager.Authenticate(user.email);
                        if (string.IsNullOrEmpty(token))
                            return Ok(false);
                        return Ok(token);
            }
            return Ok(false);

        }

        
        [HttpPost]
        [Route("decode")]
        public IActionResult login([FromBody] tokenHelper token)
        {
            var email = _tokenManager.DeCode(token.token);
            if (email != "false")
                return Ok(_userService.getData(email));
            else
                return Ok(false);
        }


        [HttpPost]
        [Route("decodeForgotPassword")]
        public IActionResult forgotPasswordDecode([FromBody] tokenHelper token)
        {
            var email = _tokenManager.DeCode(token.token);
            if (email != "false")
                return Ok(true);
            else
                return Ok(false);
        }
        [HttpPost]
        [Route("forgotPassword")]
        public IActionResult forgotPasswordEmailMessage([FromBody] tokenHelper Email)
        {
            var token = _tokenManager.forgotPasswordAuth(Email.token);
            bool sent = SendEmail(Email.token, "hello Dear \n We Detect that someone trying to reset your password for RunX App \n if that was you , please click the link and change password \n note: expires in 5 minutes " + $"http://localhost:3000/" + token);

            return Ok(sent);
        }

        public bool SendEmail(string email, string msg)
        {
            string from = "apprunx.officalMail@gmail.com"; //From address apprunx.officalMail@gmail.com  RunX1231231
            string to = email; //To address    
            MailMessage message = new MailMessage(from, to);
            string mailbody = msg;
            message.Subject = "RunX App Reset Password";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("apprunx.officalMail@gmail.com", "RunX1231231");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

    }
}
