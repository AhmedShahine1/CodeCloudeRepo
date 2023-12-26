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

    public class CategoriesController : Controller
    {
        private readonly ICategoriesRep _Ident;

        private readonly IMapper mapper;

        public CategoriesController(IMapper mapper, ICategoriesRep ident)
        {
            this.mapper = mapper;
            this._Ident = ident;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<CategoriesVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(CategoriesVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/Categories", obj.Photo);
                var data = mapper.Map<Categories>(obj);
                data.Cated_IconUrl = img;
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
            var result = mapper.Map<CategoriesVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(CategoriesVM model)
        {
            UploadCv.RemoveFile("Uploads/Categories", model.Cated_IconUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<CategoriesVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(CategoriesVM model)

        {
            if (model.Photo == null)
            {
                var url = model.Cated_IconUrl;
                var data = mapper.Map<Categories>(model);
                data.Cated_IconUrl = url;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/Categories", model.Photo);
                var data = mapper.Map<Categories>(model);
                data.Cated_IconUrl = IdentityImgUrl;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }

        }
        public IActionResult Details(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<CategoriesVM>(data);
            return View(result);
        }

    }

}
