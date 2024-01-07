using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.Api.Services.BLL;
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
        private readonly IUserService _userService;

        public SubscripeRequestsApiController(IUserService userService,ISubscripeRequestsApiRep cont)
        {
            _userService = userService;
            this._cont = cont;
        }

        

        [HttpPost]
        [Route("/api/CreateSubscripeRequests")]
        public async Task<IActionResult> CreateSubscripeRequests([FromForm] SubscripeRequestsVM obj)
        {
            var stop = await _userService.StopAsync();
            if (stop == "true")
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
            return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation" });
        }
    }

}
