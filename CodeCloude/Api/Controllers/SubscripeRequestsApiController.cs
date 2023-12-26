using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using CodeCloude.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscripeRequestsApiController : ControllerBase
    {
        private readonly ISubscripeRequestsApiRep _cont;

        public SubscripeRequestsApiController(ISubscripeRequestsApiRep cont)
        {
            this._cont = cont;
        }

        

        [HttpPost]
        [Route("/api/CreateSubscripeRequests")]
        public IActionResult CreateSubscripeRequests([FromForm] SubscripeRequestsVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                     _cont.Creat(obj);

                    CustomResponse Cusotm = new CustomResponse
                    {

                        Code = "200",
                        Message = "Request Created",
                        Status = "Done"

                    };
                    return Ok(Cusotm);
                }
                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation" });

            }
            catch (Exception)
            {

                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation" });
            }

        }
    }

}
