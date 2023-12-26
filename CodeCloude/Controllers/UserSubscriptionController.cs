using AutoMapper;
using CodeCloude.Api.Services.BLL;
using CodeCloude.BLL;
using CodeCloude.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Data;

namespace CodeCloude.Controllers
{
    [Authorize(Roles = "Admin")]

    public class UserSubscriptionController : Controller
    {
        private readonly IUserSubscriptionRep _subsc;
        private readonly IUserService _user;

        private readonly IMapper mapper;

        public UserSubscriptionController(IMapper mapper,  IUserSubscriptionRep subsc, IUserService user)
        {
            this.mapper = mapper;
            _subsc = subsc;
            _user= user;
        }

        public IActionResult Index()
        {

            var data = _subsc.Get();
            var result = mapper.Map<IEnumerable<UserSubscriptionVM>>(data);
            return View(result);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _subsc.GetById(id);
            var result = mapper.Map<UserSubscriptionVM>(data);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(UserSubscriptionVM model)
        {
            var olddata = _subsc.GetById(model.Id);
            _subsc.Delete(olddata);
            AddUserSubscriptionModel newmodel = new AddUserSubscriptionModel
            {
                userId = olddata.ApplicationUserId,
                IsSubscriped = false,
                SubscriptionName = " ",
            };
            await _user.Addsubscripe(newmodel);
            return RedirectToAction("Index");
        }



    }
}
