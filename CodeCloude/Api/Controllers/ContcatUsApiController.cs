using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContcatUsApiController : ControllerBase
    {
        private readonly IContcatUsApiRep _cont;

        public ContcatUsApiController(IContcatUsApiRep cont)
        {
            this._cont = cont;
        }



        [HttpGet]
        [Route("/api/Get_ContcatUs")]
        public IActionResult Get()
        {
            try
            {
                var data = _cont.GetAll();

                ContcatUsCustomResponse Cusotm = new ContcatUsCustomResponse
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
