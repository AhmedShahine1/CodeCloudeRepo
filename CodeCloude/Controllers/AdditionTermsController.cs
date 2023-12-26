using AutoMapper;
using CodeCloude.BLL;
using CodeCloude.Data.Entities;
using CodeCloude.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeCloude.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdditionTermsController : Controller
    {
        private readonly IAddition_TermsRep _doc;
        
        private readonly IMapper mapper;

        public AdditionTermsController(IMapper mapper, IAddition_TermsRep doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<Addition_TermsVM>>(data);
            return View(result);

        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Addition_TermsVM obj)
        {
            try
            {
                var data = mapper.Map<Addition_Terms>(obj);
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
            var result = mapper.Map<Addition_TermsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Addition_TermsVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<Addition_TermsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(Addition_TermsVM model)

        {
            var data = mapper.Map<Addition_Terms>(model);
            _doc.Edite(data);
            return RedirectToAction("Index");
        }

    }

}
