using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Terms_ConditionsApiController : ControllerBase
    {
        private readonly ITerms_ConditionsApiRep _cont;

        public Terms_ConditionsApiController(ITerms_ConditionsApiRep cont)
        {
            this._cont = cont;
        }



        [HttpGet]
        [Route("/api/GetAll_Terms_Conditions")]
        public IActionResult Get()
        {
            try
            {
                var data = _cont.GetAll();

                Terms_ConditionsCustomResponse Cusotm = new Terms_ConditionsCustomResponse
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