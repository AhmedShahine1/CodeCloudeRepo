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

    public class QuestionsController : Controller
    {
        
        private readonly IQuestionsRep _doc;

        private readonly IMapper mapper;

        public QuestionsController(IMapper mapper, IQuestionsRep doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<QuestionsVM>>(data);
            return View(result);

        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(QuestionsVM obj)
        {
            try
            {
                var data = mapper.Map<Questions>(obj);
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
            var result = mapper.Map<QuestionsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(QuestionsVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<QuestionsVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(QuestionsVM model)

        {
            var data = mapper.Map<Questions>(model);
            _doc.Edite(data);
            return RedirectToAction("Index");
        }

    }

}
