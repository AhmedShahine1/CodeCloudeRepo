using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.Api.Services.BLL;
using CodeCloude.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsApiController : ControllerBase
    {
        private readonly ISubscriptionsApiRep _cont;
        private readonly IUserService _userService;

        public SubscriptionsApiController(IUserService userService,ISubscriptionsApiRep cont)
        {
            _userService = userService;
            this._cont = cont;
        }



        [HttpGet]
        [Route("/api/GetAll_Subscriptions")]
        public async Task<IActionResult> Get()
        {
            var stop = await _userService.StopAsync();
            if (stop == "true")
            {
                try
                {
                    var data = _cont.GetAll();

                    SubscriptionsCustomResponse Cusotm = new SubscriptionsCustomResponse
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
            return NotFound(new CustomResponse
            {
                Code = "400",
                Message = "",
                Status = "Faild"
            });
        }

    }
}
