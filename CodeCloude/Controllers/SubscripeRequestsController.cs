using AutoMapper;
using CodeCloude.Api.Services.BLL;
using CodeCloude.BLL;
using CodeCloude.Data.Entities;
using CodeCloude.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CodeCloude.Controllers
{
    [Authorize(Roles = "Admin")]

    public class SubscripeRequestsController : Controller
    {
        private readonly ISubscripeRequestsRep _doc;
        private readonly IUserSubscriptionRep _subsc;
        private readonly IUserService _user;

        private readonly IMapper mapper;

        public SubscripeRequestsController(IMapper mapper, ISubscripeRequestsRep doc, IUserSubscriptionRep subsc , IUserService user)
        {
            this.mapper = mapper;
            this._doc = doc;
            _subsc = subsc;
            _user = user;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<SubscripeRequestsVM>>(data);
            return View(result);

        }

        [HttpGet]
        public IActionResult Accept(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<SubscripeRequestsVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Accept(SubscripeRequestsVM req)
        {
            
            
            try
            {
                var request = _doc.GetById(req.Id);
                UserSubscriptionVM obj = new UserSubscriptionVM
                {
                    ApplicationUserId = request.ApplicationUserId,
                    SubscriptionId = request.SubscriptionId,
                    SubscriptionDate = DateTime.Now,
                    
                };
                var data = mapper.Map<UserSubscription>(obj); 


                AddUserSubscriptionModel model = new AddUserSubscriptionModel
                {
                    userId = data.ApplicationUserId,
                    IsSubscriped = true,
                    SubscriptionName = request.Subscriptions.Subscription_Title,

                };
                _subsc.Creat(data);

                await _user.Addsubscripe(model);


                request.IsAccepted = true;

                _doc.Edite(request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

         [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<SubscripeRequestsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(SubscripeRequestsVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }


        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(SubscripeRequestsVM obj)
        {
            try
            {
                var data = mapper.Map<SubscripeRequests>(obj);
                _doc.Creat(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

      



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<SubscripeRequestsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(SubscripeRequestsVM model)

        {
            var data = mapper.Map<SubscripeRequests>(model);
            _doc.Edite(data);
            return RedirectToAction("Index");
        }

    }

}
