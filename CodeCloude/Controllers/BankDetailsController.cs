using AutoMapper;
using CodeCloude.BLL;
using CodeCloude.Data.Entities;
using CodeCloude.Models;
using System.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeCloude.Controllers
{
    [Authorize(Roles = "Admin")]

    public class BankDetailsController : Controller
    {
        private readonly IBankDetailsRep _doc;

        private readonly IMapper mapper;

        public BankDetailsController(IMapper mapper, IBankDetailsRep doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<BankDetailsVM>>(data);
            return View(result);

        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(BankDetailsVM obj)
        {
            try
            {
                var data = mapper.Map<BankDetails>(obj);
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
            var result = mapper.Map<BankDetailsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(BankDetailsVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<BankDetailsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(BankDetailsVM model)

        {
            var data = mapper.Map<BankDetails>(model);
            _doc.Edite(data);
            return RedirectToAction("Index");
        }

    }

}
