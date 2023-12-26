using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CodeCloude.Api.Bll.CategoriesApiRep;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoriesApiRep _cont;

        public CategoriesApiController(ICategoriesApiRep cont)
        {
            this._cont = cont;
        }



        [HttpGet]
        [Route("/api/GetAllCategories")]
        public IActionResult Get()
        {
            try
            {
                var data = _cont.GetAll();

                CategoriesCustomResponse Cusotm = new CategoriesCustomResponse
                {

                    Records = data,
                    Code = "200",
                    Message = "Data Returned",
                    Status = "Done"

                };
                return Ok(Cusotm);
            }
            catch (Exception ex)
            {
                return NotFound(new CustomResponse
                {
                    Code = "400",
                    Message = ex.Message,
                    Status = "Faild"
                });

            }
        }

    }
}
