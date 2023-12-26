using AutoMapper;
using CodeCloude.BLL;
using CodeCloude.Data.Entities;
using CodeCloude.Models;
using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace CodeCloude.Controllers
{
    [Authorize(Roles = "Admin")]

    public class StoresController : Controller
    {
        private readonly IStoresRep _Ident;
        private readonly ICategoriesRep _catg;
        private readonly ICountriesRep _count;

        private readonly IMapper mapper;

        public StoresController(IMapper mapper, IStoresRep ident, ICategoriesRep catg, ICountriesRep count)
        {
            this.mapper = mapper;
            this._Ident = ident;
            _catg = catg;
            _count = count;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<StoresVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {

            var cats = _catg.Get();
            ViewBag.Categs = new SelectList(cats , "Id", "Categ_Name");

            var counts = _count.Get();
            ViewBag.countriesLis = new SelectList(counts, "Id", "Cont_Name");

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(StoresVM obj)
        {

            var cats = _catg.Get();
            ViewBag.Categs = new SelectList(cats, "Id", "Categ_Name");

            var counts = _count.Get();
            ViewBag.countriesLis = new SelectList(counts, "Id", "Cont_Name");
            try
            {
                var img = UploadCv.uploadFile("Uploads/Stores", obj.Photo);
                var data = mapper.Map<Stores>(obj);
                data.Stor_ImgUrl = img;
                _Ident.Creat(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }    
        [HttpGet]

        public IActionResult CreateSpecial(int id)
        {
            var cats = _catg.Get();
            ViewBag.Categs = new SelectList(cats, "Id", "Categ_Name");

            var counts = _count.Get();
            ViewBag.countriesLis = new SelectList(counts, "Id", "Cont_Name");


            var data = _Ident.GetById(id);
            var result = mapper.Map<StoresVM>(data);
            return View(result);
        }
        [HttpPost]

        public async Task<IActionResult> CreateSpecial(StoresVM model)
        {
            var data = _Ident.GetById(model.Id);
            data.IsSpecial = true;
            _Ident.Edite(data);
            return RedirectToAction("Index");

        }
        [HttpGet]

        public IActionResult DeletteSpecial(int id)
        {
            var cats = _catg.Get();
            ViewBag.Categs = new SelectList(cats, "Id", "Categ_Name");

            var counts = _count.Get();
            ViewBag.countriesLis = new SelectList(counts, "Id", "Cont_Name");


            var data = _Ident.GetById(id);
            var result = mapper.Map<StoresVM>(data);
            return View(result);
        }
        [HttpPost]

        public async Task<IActionResult> DeletteSpecial(StoresVM model)
        {
            var data = _Ident.GetById(model.Id);
            data.IsSpecial = false;
            _Ident.Edite(data);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<StoresVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(StoresVM model)
        {
            UploadCv.RemoveFile("Uploads/Stores", model.Stor_ImgUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var cats = _catg.Get();
            ViewBag.Categs = new SelectList(cats, "Id", "Categ_Name");

            var counts = _count.Get();
            ViewBag.countriesLis = new SelectList(counts, "Id", "Cont_Name");


            var data = _Ident.GetById(id);
            var result = mapper.Map<StoresVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(StoresVM model)

        {
            if (model.Photo == null)
            {
                var url = model.Stor_ImgUrl;
                var data = mapper.Map<Stores>(model);
                data.Stor_ImgUrl = url;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/Stores", model.Photo);
                var data = mapper.Map<Stores>(model);
                data.Stor_ImgUrl = IdentityImgUrl;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }

        }



        [HttpPost]

        public async Task<IActionResult> AddToSpecial(int id)
        {
                var data = _Ident.GetById(id);
                data.IsSpecial = true;
                _Ident.Edite(data);
                return RedirectToAction("Index");
          
        }
        public IActionResult Details(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<StoresVM>(data);
            return View(result);
        }

    }

}
