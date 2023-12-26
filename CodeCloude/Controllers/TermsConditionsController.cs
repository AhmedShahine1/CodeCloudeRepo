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

    public class TermsConditionsController : Controller
    {
        private readonly ITerms_ConditionsRep _doc;

        private readonly IMapper mapper;

        public TermsConditionsController(IMapper mapper, ITerms_ConditionsRep doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<Terms_ConditionsVM>>(data);
            return View(result);

        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Terms_ConditionsVM obj)
        {
            try
            {
                var data = mapper.Map<Terms_Conditions>(obj);
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
            var result = mapper.Map<Terms_ConditionsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Terms_ConditionsVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<Terms_ConditionsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(Terms_ConditionsVM model)

        {
            var data = mapper.Map<Terms_Conditions>(model);
            _doc.Edite(data);
            return RedirectToAction("Index");
        }

    }

}
