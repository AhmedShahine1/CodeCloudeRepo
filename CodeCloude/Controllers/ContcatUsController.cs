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

    public class ContcatUsController : Controller
    {
        private readonly IContcatUsRep _doc;

        private readonly IMapper mapper;
        
        public ContcatUsController(IMapper mapper, IContcatUsRep doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<ContcatUsVM>>(data);
            return View(result);

        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(ContcatUsVM obj)
        {
            //try
            //{
                var data = mapper.Map<ContcatUs>(obj);
                _doc.Creat(data);
                return RedirectToAction("Index");
            //}
            //catch (Exception ex)
            //{
            //    return View();
            //}
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<ContcatUsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(ContcatUsVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<ContcatUsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(ContcatUsVM model)

        {
            var data = mapper.Map<ContcatUs>(model);
            _doc.Edite(data);
            return RedirectToAction("Index");
        }

    }

}