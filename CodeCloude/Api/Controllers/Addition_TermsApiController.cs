using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CodeCloude.Api.Bll.Addition_TermsApiRep;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Addition_TermsApiController : ControllerBase
    {
        private readonly IAddition_TermsApiRep _cont;

        public Addition_TermsApiController(IAddition_TermsApiRep cont)
        {
            this._cont = cont;
        }



        [HttpGet]
        [Route("/api/GetAll_Addition_Terms")]
        public IActionResult Get()
        {
            try
            {
                var data = _cont.GetAll();

                Addition_TermsCustomResponse Cusotm = new Addition_TermsCustomResponse
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
