//using Pharmacy_Project.Api.Interfaces;
using CodeCloude.Api.Models;
using Microsoft.AspNetCore.Mvc;
using CodeCloude.Models;
using CodeCloude.API.Models;
using CodeCloude.Api.Services.BLL;
using Microsoft.AspNetCore.Identity;
using CodeCloude.Extend;
using EmailService;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IUserService _userService;
        private IConfiguration _configuration;
        IEmailSender _emailSender;


        public AuthController(IUserService userService ,IConfiguration configuration, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
 
            _userService = userService;
            //_mailService = mailService;
            _configuration = configuration;
            _userManager = userManager;
            _emailSender = emailSender;

        }

        [HttpPost("Register/{Count_Id}")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model, int Count_Id)
        {
            var stop = await _userService.StopAsync();
            if (stop == "true")
            {
                model.CountryId = Count_Id;

                if (ModelState.IsValid)
                {
                    var result = await _userService.RegisterUserAsync(model);
                    if (result.IsSuccess)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);
                }
                return BadRequest("Some Inputs are not valid !"); // status code 400
            }
            return BadRequest("Some Inputs are not valid !"); // status code 400
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync( LoginModel model)
        {
            var stop = await _userService.StopAsync();
            if (stop == "true")
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.LoginUserAsync(model);

                    if (result.IsSuccess)
                    {
                        //await _mailService.SendEmailAsync(model.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
                        return Ok(result);
                    }

                    return BadRequest(result);
                }

                return BadRequest("Some properties are not valid");
            }
            return BadRequest("Some properties are not valid");
        }


    [HttpPost("ForgetPassword/{email}")]
        public async Task<IActionResult> ForgetPassword(string email, IFormFileCollection attachments)
        {
            if (string.IsNullOrEmpty(email))
            {

                return NotFound();
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = email, Token = token }, Request.Scheme);
                var messages = new Message(new string[] { email }, "Reset Password url ", passwordResetLink, attachments, token);
                await _emailSender.SendEmailAsync2(messages, email, "Reset Password url ", passwordResetLink);

                var Succesrespon = new UserManagerResponse
                {

                    IsSuccess = true,
                    Message = "Reset password URL has been sent to the email successfully!",
                    Token = token,
                };

                return Ok(Succesrespon); // 200

            }
            var respon = new UserManagerResponse
            {
                IsSuccess = false,
                Message = "User Not Found!",
            };

            return BadRequest(respon); // 200


        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ResetPasswordAsync(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }


        [HttpPost("GetAccountData/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var stop = await _userService.StopAsync();
            CustomResponse customResponse = new CustomResponse();
            if (stop == "true")
            {
                var data = _userService.GetAccount(id);

                if (data != null)
                {
                    UserAccountCustomRespons Cusotm = new UserAccountCustomRespons()

                    {
                        Record = await data,
                        Code = "200",
                        Message = "Data Returned",
                        Status = "Done"

                    };
                    return Ok(Cusotm);

                }
                customResponse = new CustomResponse()
                {
                    Code = "400",
                    Message = "There Is No User With This Id",
                    Status = "Faild"
                };
                return Ok(customResponse);

            }
            customResponse = new CustomResponse()
            {
                Code = "400",
                Message = "There Is No User With This Id",
                Status = "Faild"
            };
            return Ok(customResponse);

        }


        [HttpPost("EditeAccount/{id}")]
        public async Task<IActionResult> EditeAccount(string id,[FromForm] EditeProfileModel model)
        {

            if (ModelState.IsValid)
            {
                model.Id = id;
                var data = await _userService.EditeProffile(model);

                if (data.IsSuccess)

                {
                    return Ok(data);
                }

                return BadRequest(data);
            }

            return BadRequest("Some properties are not valid");


        }
       

        [HttpPost("EditePassword/{id}")]
        public async Task<IActionResult> EditePassword(string id, [FromBody] EditePassword model)
        {

            if (ModelState.IsValid)
            {
                model.Id = id;
                var data = await _userService.EditePassword(model);

                if (data.IsSuccess)

                {
                    return Ok(data);
                }

                return BadRequest(data);
            }

            return BadRequest("Some properties are not valid");


        }

        [HttpGet("ApplePayActive")]
        public IActionResult ApplePayActive()
        {
            return Ok(true);
        }
    }
}
