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

    public class CountriesController : Controller
    {
        private readonly ICountriesRep _Ident;

        private readonly IMapper mapper;

        public CountriesController(IMapper mapper, ICountriesRep ident)
        {
            this.mapper = mapper;
            this._Ident = ident;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<CountriesVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(CountriesVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/Countries", obj.Photo);
                var data = mapper.Map<Countries>(obj);
                data.Cont_FlagUrl = img;
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
            var result = mapper.Map<CountriesVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(CountriesVM model)
        {
            UploadCv.RemoveFile("Uploads/Countries", model.Cont_FlagUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<CountriesVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(CountriesVM model)

        {
            if (model.Photo == null)
            {
                var url = model.Cont_FlagUrl;
                var data = mapper.Map<Countries>(model);
                data.Cont_FlagUrl = url;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/Countries", model.Photo);
                var data = mapper.Map<Countries>(model);
                data.Cont_FlagUrl = IdentityImgUrl;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }

        }

    }

}
