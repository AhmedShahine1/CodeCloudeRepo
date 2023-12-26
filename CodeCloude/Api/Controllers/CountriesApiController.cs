using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesApiController : ControllerBase
    {
        private readonly ICountriesApiRep _cont;

        public CountriesApiController(ICountriesApiRep cont)
        {
            this._cont = cont;
        }



        [HttpGet]
        [Route("/api/GetAll_Countries")]
        public IActionResult Get()
        {
            try
            {
                var data = _cont.GetAll();

                CountriesCustomResponse Cusotm = new CountriesCustomResponse
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