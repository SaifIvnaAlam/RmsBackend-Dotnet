using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RmsBackend.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/products")]
        public HttpResponseMessage products()
        {
            try
            {
                var data = ProductService.GetAllProducts();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);  
            }
        }
        [HttpGet]
        [Route("api/product/{id}")]
        public HttpResponseMessage product(int id)
        {
            try
            {
                var data = ProductService.GetProduct(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/product/create")]
        public HttpResponseMessage Create(ProductDTO data)
        {
            try
            {
                var res = ProductService.Create(data);
                if(res== true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new {Massage ="Product Has Been Created Successfully"});

                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Massage = "Product Wasn't Created. Please Provide Valid informations" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/product/delete/{id}")]
        public HttpResponseMessage Delete(int Id) //int id
        {
              
            {
                try
                {
                    var res = ProductService.Delete(Id);
                    if (res == true)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });
                    }
                    else { return Request.CreateResponse(HttpStatusCode.NoContent, new { Message = "Product No Found" }); }

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            
        }

    }
}
