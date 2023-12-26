using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class privacypolicyApiController : ControllerBase
    {
        private readonly IprivacypolicyApiRep _cont;

        public privacypolicyApiController(IprivacypolicyApiRep cont)
        {
            this._cont = cont;
        }



        [HttpGet]
        [Route("/api/GetAll_privacypolicy")]
        public IActionResult Get()
        {
            try
            {
                var data = _cont.GetAll();

                privacypolicyCustomResponse Cusotm = new privacypolicyCustomResponse
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
