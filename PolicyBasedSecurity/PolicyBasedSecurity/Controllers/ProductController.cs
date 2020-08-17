using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service;
using Business.Utils;
using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PolicyBasedSecurity.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IBusinessService _businessService;

        public ProductController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        // GET api/product
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = PermissionRegister.GetProduct)]
        public ActionResult GetAll()
        {
            var listProduct = _businessService.GetAllProduct();
            return Ok(listProduct);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = PermissionRegister.GetProduct)]
        public IActionResult Get(int id)
        {
            var product = _businessService.GetProductById(id);
            return Ok(product);
        }

        // POST api/product
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = PermissionRegister.CreateProduct)]
        public IActionResult Post([FromBody] Product product)
        {
            var result = _businessService.AddProduct(product);
            return Ok(result);
        }

        // PUT api/product/5
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = PermissionRegister.EditProduct)]
        public IActionResult Put([FromBody] Product product)
        {
            var result = _businessService.UpdateProduct(product);
            return Ok(result);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = PermissionRegister.DeleteProduct)]
        public IActionResult Delete(int id)
        {
            var result = _businessService.DeleteProductById(id);
            return Ok(result);
        }
    }
}
