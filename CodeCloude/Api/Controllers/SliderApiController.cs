using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CodeCloude.Api.Bll.SliderApiRep;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderApiController : ControllerBase
    {
        private readonly ISliderApiRep _cont;

        public SliderApiController(ISliderApiRep cont)
        {
            this._cont = cont;
        }



        [HttpGet]
        [Route("/api/GetAllSlider")]
        public IActionResult Get()
        {
            try
            {
                var data = _cont.GetAll();

                SliderCustomResponse Cusotm = new SliderCustomResponse
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
