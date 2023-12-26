using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankDetailsApiController : ControllerBase
    {
        private readonly IBankDetailsApiRep _cont;

        public BankDetailsApiController(IBankDetailsApiRep cont)
        {
            this._cont = cont;
        }



        [HttpGet]
        [Route("/api/GetAll_BankDetails")]
        public IActionResult Get()
        {
            try
            {
                var data = _cont.GetAll();

                BankDetailsCustomResponse Cusotm = new BankDetailsCustomResponse
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
