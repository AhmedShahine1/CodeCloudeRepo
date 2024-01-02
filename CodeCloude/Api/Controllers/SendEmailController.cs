using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.Data.Entities;
using CodeCloude.Extend;
using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Web.Helpers;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISubscriptionsApiRep _cont;
        IEmailSender _emailSender;
        public SendEmailController(IEmailSender emailSender, UserManager<ApplicationUser> userManager, ISubscriptionsApiRep cont)
        {
            _cont = cont;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        [HttpPost("SendEmailAdmin")]
        public async Task<IActionResult> SendEmailAdmin(string userId,string SubscriptionId,string Money)
        {
            var respon = new UserManagerResponse();
            var User = await _userManager.FindByIdAsync(userId);
            if (User == null)
            {
                respon.IsSuccess = false;
                respon.Message = "User Not Found!";
                return BadRequest(respon);
            }
            IEnumerable<Subscriptions> Subscription = _cont.GetById(SubscriptionId);
            Subscriptions subscriptions = new Subscriptions();
            foreach (var sub in Subscription)
            {
                subscriptions.Ads_Number = sub.Ads_Number;
                subscriptions.Subscription_Period = sub.Subscription_Period;
                subscriptions.Subscription_Title = sub.Subscription_Title;
            }
            if (Subscription == null)
            {
                respon.IsSuccess = false;
                respon.Message = "Subscription Not Found!";
                return BadRequest(respon);
            }
            string email = "info@codecloudsa.com";
            string content = $"Email User:{User.Email},      Phone Number :{User.PhoneNumber},       Subscription Title :{subscriptions.Subscription_Title},        Subscription Period :{subscriptions.Subscription_Period},        Subscription Ads Number :{subscriptions.Ads_Number},       User Pay: {Money}.";
            var messages = new Message(email , "Pay Subscription", content,null);
            await _emailSender.SendEmailAsync3(messages, email, "Pay Subscription", content);

            respon.IsSuccess = true;
            respon.Message = "Notification has been sent to the email successfully!";
            return Ok(respon);
        }
    }
}
