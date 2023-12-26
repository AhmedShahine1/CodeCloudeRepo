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
    public class UserFaviouritesApiController : ControllerBase
    {
        private readonly IUser_FaviouritesApiRep _cont;

        public UserFaviouritesApiController(IUser_FaviouritesApiRep cont)
        {
            this._cont = cont;
        }

        [HttpPost]
        [Route("/api/CreateUser_Faviourites")]
        public IActionResult CreateUser_Faviourites( User_FaviouritesVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _cont.Creat(obj);

                    CustomResponse Cusotm = new CustomResponse
                    {

                        Code = "200",
                        Message = "Succsed ",
                        Status = "Done"

                    };
                    return Ok(Cusotm);
                }
                return StatusCode(400, new CustomResponse { Code = "400", Message = "Faild" });

            }
            catch (Exception)
            {

                return StatusCode(400, new CustomResponse { Code = "400", Message = "Faild" });
            }

        }
        [HttpPost]
        [Route("/api/Get_Faviourites_byUserId/{Userid}")]
        public IActionResult GetbyId(string Userid)
        {
            try
            {


                var data = _cont.GetById(Userid);
                if (data != null)
                {
                    FaviouritesCustomResponse Cusotm = new FaviouritesCustomResponse
                    {

                        newRecords = data,
                        Code = "200",
                        Message = "Data Returned",
                        Status = "Done"

                    };
                    return Ok(Cusotm);
                }

                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid id" });



            }
            catch (Exception)
            {

                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation" });
            }

        }



        [HttpDelete]
        [Route("/api/DeleteFaviourite/{id}")]
        public IActionResult DeleteFav(int id)
        {

            try
            {

                if (ModelState.IsValid)
                {
                     _cont.Delete(id);

                    CustomResponse Cusotm = new CustomResponse
                    {

                        Code = "200",
                        Message = "Faviourite Deleted ",
                        Status = "Done"

                    };
                    return Ok(Cusotm);

                }

                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation" });

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
        
        
        [HttpDelete]
        [Route("/api/DeleteFaviouriteById")]
        public IActionResult DeleteFav(int Productid,string userId)
        {

            try
            {

                if (ModelState.IsValid)
                {
                     _cont.DeleteFav(userId, Productid);

                    CustomResponse Cusotm = new CustomResponse
                    {

                        Code = "200",
                        Message = "Faviourite Deleted ",
                        Status = "Done"

                    };
                    return Ok(Cusotm);

                }

                return StatusCode(400, new CustomResponse { Code = "400", Message = "Invalid Data Annotation" });

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
