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

    public class User_FaviouritesController : Controller
    {
        private readonly IUser_FaviouritesRep _doc;

        private readonly IMapper mapper;

        public User_FaviouritesController(IMapper mapper, IUser_FaviouritesRep doc)
        {
            this.mapper = mapper;
            this._doc = doc;
        }

        public IActionResult Index()
        {
            var data = _doc.Get();
            var result = mapper.Map<IEnumerable<User_FaviouritesVM>>(data);
            return View(result);

        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(User_FaviouritesVM obj)
        {
            try
            {
                var data = mapper.Map<User_Faviourites>(obj);
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
            var result = mapper.Map<User_FaviouritesVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(User_FaviouritesVM model)
        {
            var olddata = _doc.GetById(model.Id);
            _doc.Delete(olddata);
            return RedirectToAction("Index");
        }

        

        [HttpGet]
        public IActionResult Edite(int id)
        {
            var data = _doc.GetById(id);
            var result = mapper.Map<User_FaviouritesVM>(data);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edite(User_FaviouritesVM model)

        {
            var data = mapper.Map<User_Faviourites>(model);
            _doc.Edite(data);
            return RedirectToAction("Index");
        }

    }

}
