
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EmailService;
using Microsoft.AspNetCore.Authorization;
using CodeCloude.Models;
using CodeCloude.Extend;
using Microsoft.AspNetCore.Mvc.Rendering;
using CodeCloude.BLL;
using CodeCloude.Api.Services.BLL;
using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Helper;


namespace CodeCloude.Api.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        private IConfiguration _configuration;
        //private IMailService _mailService;
        IEmailSender _emailSender;


        public UserService(Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager, IEmailSender emailSender,
            Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _emailSender = emailSender;
            _roleManager = roleManager;
            //_mailService = mailService;


        }



        public async Task<UserManagerResponse> RegisterUserAsync(RegisterModel model)
        {
            if (model == null)
                throw new NullReferenceException("Reigster Model is null");


            var user = new ApplicationUser

            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Count_Id = model.CountryId,


            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {


                var defaultrole = _roleManager.FindByNameAsync("User").Result;

                if (defaultrole != null)
                {
                    IdentityResult roleresult = await _userManager.AddToRoleAsync(user, defaultrole.Name);
                }


                var claims = new[]
            {
                new Claim("Id", user.Id),
                new Claim("FullName", user.FullName),
                new Claim("Email", model.Email),
                new Claim("PhoneNumber",$"{user.PhoneNumber}"),
                new Claim("IsSubscriped",$"{user.IsSubscribed}"),
                 new Claim("CountId",$"{user.Count_Id}"),
                 new Claim("SubscriptionName",$"{user.SubscriptionName}"),

            };


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                     claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                    Token = tokenAsString
                };

            }

            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }


        public async Task<UserManagerResponse> LoginUserAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
                return new UserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };


            var claims = new[]
          {
                new Claim("Id", user.Id),
                //new Claim("FullName", user.FullName),
                new Claim("Email", model.Email),
               // new Claim("PhoneNumber",$"{user.PhoneNumber}"),
               // new Claim("ImgUrl", $"{user.ImgUrl}"),
               // new Claim("CountId",$"{user.Count_Id}"),
                new Claim("IsSubscriped",$"{user.IsSubscribed}"),
               new Claim("SubscriptionName",$"{user.SubscriptionName}"),


        };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = "User Login successfully!",
                IsSuccess = true,
                ExpireDate = token.ValidTo,
                Token = tokenAsString,

            };
        }

        public async Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Email confirmed successfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                IsSuccess = false,
                Message = "Email did not confirm",
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserManagerResponse> ForgetPasswordAsync(string Email, IFormFileCollection attachments)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/ResetPassword?email={Email}&token={validToken}";

            var messages = new EmailService.Message(new string[] { Email }, "There is some one need to reset password , Is that you !? ", token, attachments, token);
            await _emailSender.SendEmailAsync2(messages, Email, token, token);

            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Reset password URL has been sent to the email successfully!",
                Token = validToken,
            };
        }

        public async Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            if (model.NewPassword != model.ConfirmPassword)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Password doesn't match its confirmation",
                };

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);

            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Password has been reset successfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }

        public async Task<UserModel> GetAccount(string id)
        {
            var data = await _userManager.FindByIdAsync(id);

            UserModel obj = new UserModel()
            {
                Name = data.FullName,
                Phone = data.PhoneNumber,
                ImgUrl = "/Uploads/Users/" + data.ImgUrl,
                Gender = data.Gender,
                Email = data.Email,
                Id = data.Id,
                userNAme = data.UserName,
                //CountryId = data.CountriesId

                //Country = data.Country,

            };
            return obj;
        }

        public async Task<EditeAccountCustomRespon> EditeProffile(EditeProfileModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (model.Email == null)
            {
                model.Email = user.Email;
            }
            //chek user exist
            if (user == null)
            {
                EditeAccountCustomRespon custom = new EditeAccountCustomRespon()
                {
                    Code = "400",
                    Message = "User Not Found",
                    Status = "Faild",
                    IsSuccess = false,
                };
                return (custom);
            }

            //check user name and Email 
            var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
            if (userWithSameEmail != null && userWithSameEmail.Id != model.Id)
            {

                EditeAccountCustomRespon custom = new EditeAccountCustomRespon()
                {
                    Code = "400",
                    Message = "Email is Used ",
                    Status = "Faild",
                    IsSuccess = false,
                };
                return (custom);
            }




            user.Email = model.Email;
            user.FullName = model.Name;
            user.PhoneNumber = model.Phone;
            user.UserName = model.Email;
            user.Gender = model.Gender;
            //user.CountriesId = model.CountryId;
            if (model.Id != null)
            {
                //user.CountryId = model.CountryId;
            }

            if (model.Photo != null)
            {
                var img = UploadCv.uploadFile("Uploads/Users", model.Photo);
                user.ImgUrl = img;
            }


            var result = await _userManager.UpdateAsync(user);



            var claims = new[]
{
                new Claim("Id", user.Id),
                new Claim("FullName", user.FullName),
                new Claim("Email", model.Email),
                new Claim("PhoneNumber",$"{user.PhoneNumber}"),
                new Claim("ImgUrl", $"{user.ImgUrl}"),
                new Claim("CountId",$"{user.Count_Id}"),
                new Claim("IsSubscriped",$"{user.IsSubscribed}"),
                                 new Claim("SubscriptionName",$"{user.SubscriptionName}"),


                 //new Claim("CountId",$"{user.CountriesId}"),
        };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            if (result.Succeeded)
            {
                EditeAccountCustomRespon custom = new EditeAccountCustomRespon()
                {
                    Message = "Account Updated Successfully",
                    Code = "200",
                    Status = "succeed",
                    IsSuccess = true,
                    Token = tokenAsString,

                };
                return (custom);
            }
            else
            {
                EditeAccountCustomRespon custom = new EditeAccountCustomRespon()
                {
                    Code = "400",
                    Message = "Something is wrong ",
                    Status = "Faild",
                    IsSuccess = false,
                };
                return (custom);
            }


        }
        public async Task Addsubscripe(AddUserSubscriptionModel model)
        {
            var user = await _userManager.FindByIdAsync(model.userId);
            user.SubscriptionName=model.SubscriptionName;
            user.IsSubscribed= model.IsSubscriped;
            await _userManager.UpdateAsync(user);

        }
        public IEnumerable<ApplicationUser> Getusers()
        {
            var users = _userManager.Users;
            return users;
        }

        public async Task<UserManagerResponse> EditePassword(EditePassword model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            //Check old Password
            var oldpasword = await _userManager.CheckPasswordAsync(user, model.OldPaassword);
            if (!oldpasword)
                return new UserManagerResponse
                {
                    Message = "Invalid Old password",
                    IsSuccess = false,
                };
            //Check Password Confirmation
            if (model.NewPassword != model.ConfirmNewPassword)
                return new UserManagerResponse
                {
                    IsSuccess = false,
                    Message = "Password doesn't match its confirmation",
                };


            //Generate User Token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            //Edite Password

            var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
            if (result.Succeeded)
                return new UserManagerResponse
                {
                    Message = "Password has been Edited successfully!",
                    IsSuccess = true,
                };

            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }
    }
}
