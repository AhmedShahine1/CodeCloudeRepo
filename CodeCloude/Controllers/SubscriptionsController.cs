using AutoMapper;
using CodeCloude.BLL;
using CodeCloude.Data.Entities;
using CodeCloude.Models;
using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CodeCloude.Controllers
{
    [Authorize(Roles = "Admin")]

    public class SubscriptionsController : Controller
    {
        private readonly ISubscriptionsRep _Ident;

        private readonly IMapper mapper;

        public SubscriptionsController(IMapper mapper, ISubscriptionsRep ident)
        {
            this.mapper = mapper;
            this._Ident = ident;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<SubscriptionsVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(SubscriptionsVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/Subscriptions", obj.Photo);
                var data = mapper.Map<Subscriptions>(obj);
                data.ImgUrl = img;
                _Ident.Creat(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<SubscriptionsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(SubscriptionsVM model)
        {
            UploadCv.RemoveFile("Uploads/Subscriptions", model.ImgUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<SubscriptionsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(SubscriptionsVM model)

        {
            if (model.Photo == null)
            {
                var url = model.ImgUrl;
                var data = mapper.Map<Subscriptions>(model);
                data.ImgUrl = url;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/Subscriptions", model.Photo);
                var data = mapper.Map<Subscriptions>(model);
                data.ImgUrl = IdentityImgUrl;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }

        }

    }

}
