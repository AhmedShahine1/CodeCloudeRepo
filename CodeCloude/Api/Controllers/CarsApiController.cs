//using Microsoft.AspNetCore.Mvc;
//using CodeCloude.Api.Bll;
//using CodeCloude.Api.Models;
//using CodeCloude.API.Models;
//using static CodeCloude.Api.Bll.CarApiRep;

//namespace CodeCloude.Api.Controllers
//{
//  [Route("api/[controller]")]
//        [ApiController]
//        public class CarsApiController : ControllerBase
//        {
//            private readonly ICarApiRep employee;

//            public CarsApiController(ICarApiRep employee)
//            {
//                this.employee = employee;
//            }



//            [HttpGet]
//            [Route("/api/GetAllCars")]
//            public IActionResult Get()
//            {
//                try
//                {
//                    var data = employee.GetAll();

//                    CarsCustomResponse Cusotm = new CarsCustomResponse
//                    {

//                        Records = data,
//                        Code = "200",
//                        Message = "Data Returned",
//                        Status = "Done"

//                    };
//                    return Ok(Cusotm);
//                }
//                catch (Exception ex)
//                {
//                    return NotFound(new CustomResponse
//                    {
//                        Code = "400",
//                        Message = ex.Message,
//                        Status = "Faild"
//                    });

//                }
//            }

//        }
//    }
