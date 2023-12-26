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

    public class SliderController : Controller
    {
        
        private readonly ISliderRep _Ident;

        private readonly IMapper mapper;

        public SliderController(IMapper mapper, ISliderRep ident)
        {
            this.mapper = mapper;
            this._Ident = ident;
        }

        public IActionResult Index()
        {
            var data = _Ident.Get();
            var result = mapper.Map<IEnumerable<SliderVM>>(data);
            return View(result);

        }



        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(SliderVM obj)
        {
            try
            {
                var img = UploadCv.uploadFile("Uploads/Slider", obj.Photo);
                var data = mapper.Map<Slider>(obj);
                data.Slider_ImgUrl = img;
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
            var result = mapper.Map<SliderVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(SliderVM model)
        {
            UploadCv.RemoveFile("Uploads/Slider", model.Slider_ImgUrl);
            var olddata = _Ident.GetById(model.Id);
            _Ident.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _Ident.GetById(id);
            var result = mapper.Map<SliderVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(SliderVM model)

        {
            if (model.Photo == null)
            {
                var url = model.Slider_ImgUrl;
                var data = mapper.Map<Slider>(model);
                data.Slider_ImgUrl = url;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }
            else
            {
                var IdentityImgUrl = UploadCv.uploadFile("Uploads/Slider", model.Photo);
                var data = mapper.Map<Slider>(model);
                data.Slider_ImgUrl = IdentityImgUrl;
                _Ident.Edite(data);
                return RedirectToAction("Index");
            }

        }

    }

}
