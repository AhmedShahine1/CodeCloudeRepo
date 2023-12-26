using AutoMapper;
using CodeCloude.BLL;
using CodeCloude.Data.Entities;
using CodeCloude.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CodeCloude.Controllers
{
    [Authorize(Roles = "Admin")]

    public class privacypolicyController : Controller
    {
        private readonly IprivacypolicyRep _doc;

        private readonly IMapper mapper;

        public privacypolicyController(IMapper mapper, IprivacypolicyRep doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<privacypolicyVM>>(data);
            return View(result);

        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(privacypolicyVM obj)
        {
            try
            {
                var data = mapper.Map<privacypolicy>(obj);
                _doc.Creat(data);
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
            var data = _doc.GetById(id);
            var result = mapper.Map<privacypolicyVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(privacypolicyVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<privacypolicyVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(privacypolicyVM model)

        {
            var data = mapper.Map<privacypolicy>(model);
            _doc.Edite(data);
            return RedirectToAction("Index");
        }

    }

}
