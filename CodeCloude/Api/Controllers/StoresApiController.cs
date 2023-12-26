using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeCloude.Api.Bll;
using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using CodeCloude.Models;
using System.Linq;
using CodeCloude.Data.Entities;
using System.Collections.Generic;

namespace CodeCloude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresApiController : ControllerBase
    {
        private readonly IStoresApiRep _cont;
        private readonly IUser_FaviouritesApiRep _fav;
        
        public StoresApiController(IStoresApiRep cont, IUser_FaviouritesApiRep fav)
        {
            this._cont = cont;
            this._fav = fav;
        }




        [HttpPost]
        [Route("/api/GetAllStores/{Country_ID}")]
        public async Task<IActionResult> GetAsync([FromBody] SerachModel model, int Country_ID)
        {
            List<StoresVM> resultdata = new List<StoresVM>();

            model.count_id = Country_ID;
            if (model.SearchValue != null || model.SearchValue != "")
            {
                try
                {
                    var Searched = await _cont.SearchStores(model.SearchValue);

                    var data = Searched.Where(a => a.CountId == model.count_id);
                   
                    if (data.Count() != 0)
                    {

                        foreach (var item in data)
                        {

                            foreach (var favitem in item.User_Faviourites)
                            {
                                if (favitem.userId == model.userId)
                                {
                                    item.isFaviourite = true;
                                    break;
                                }


                            }
                            resultdata.Add(item);
                        }
                        StoresCustomResponse Cusotm = new StoresCustomResponse
                        {

                            Records = resultdata,
                            Code = "200",
                            Message = "Data Returned",
                            Status = "Done"

                        };
                        return Ok(Cusotm);
                    }
                    else
                    {
                        return NotFound(new CustomResponse
                        {
                            Code = "405",
                            Message = "No Data",
                            Status = "Faild"
                        });
                    }


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
            else
            {
                try
                {
                    var data = _cont.GetAll(model.count_id);
                    foreach (var item in data)
                    {

                        foreach (var favitem in item.User_Faviourites)
                        {
                            if (favitem.userId == model.userId)
                            {
                                item.isFaviourite = true;
                                break;
                            }


                        }
                        resultdata.Add(item);
                    }
                    StoresCustomResponse Cusotm = new StoresCustomResponse
                    {

                        Records = resultdata,
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
        [Route("/api/GetByCatgId/{Id}")]
        public async Task<IActionResult> GetByCatgIdAsync(int id, [FromBody] SerachModel model)
        {
            List<StoresVM> resultdata = new List<StoresVM>();
            if (id != null && id != 0)
            {
                try
                {

                    var result = await _cont.GetByCategId(id);
                    var data = result.Where(a => a.CountId == model.count_id);
                    foreach (var item in data)
                    {

                        foreach (var favitem in item.User_Faviourites)
                        {
                            if (favitem.userId == model.userId)
                            {
                                item.isFaviourite = true;
                                break;
                            }


                        }
                        resultdata.Add(item);
                    }

                    StoresCustomResponse Cusotm = new StoresCustomResponse
                    {

                        Records = resultdata,
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
            else
            {
                try
                {

                    var data = _cont.GetAll(model.count_id);
                    foreach (var item in data)
                    {

                        foreach (var favitem in item.User_Faviourites)
                        {
                            if (favitem.userId == model.userId)
                            {
                                item.isFaviourite = true;
                                break;
                            }


                        }
                        resultdata.Add(item);
                    }


                    StoresCustomResponse Cusotm = new StoresCustomResponse
                    {

                        Records = resultdata,
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


        [HttpPost]
        [Route("/api/Get_Store_byId/{id}")]
        public IActionResult GetbyId(int id)
        {
            //StoresVM resultdata = new StoresVM();

            try
            {


                var data = _cont.GetById(id);
               
                if (data != null)
                {
                   

                        //foreach (var favitem in data.User_Faviourites)
                        //{
                        //    if (favitem.userId == /*data.userId*/)
                        //    {
                        //    data.isFaviourite = true;
                        //        break;
                        //    }


                        //}
                   
                    StoresCustomResponse Cusotm = new StoresCustomResponse
                    {

                        Record = data,
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

        [HttpPost]
        [Route("/api/CreateStore")]
        public IActionResult CreateStore([FromForm] StoresVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = _cont.Creat(obj);

                    StoresCustomResponse Cusotm = new StoresCustomResponse
                    {

                        Record = data,
                        Code = "200",
                        Message = "Store Craeted",
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

        [HttpGet]
        [Route("/api/GetSpecial")]
        public IActionResult GetSpecial()
        {

            try
            {
                var data = _cont.GetAllSpecial().Where(a=> a.IsSpecial==true);

                StoresCustomResponse Cusotm = new StoresCustomResponse
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
