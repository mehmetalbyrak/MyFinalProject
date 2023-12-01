using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    { 
        // Loosely coupled
        // Naming convention
        // IoC Container -- Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        
        // -- HTTP Methods -- 
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            // Swagger
            // Dependency chain --
       
             var result = _productService.GetAll();
             if (result.Success)
             {
                 return Ok(result);
             }
             return BadRequest(result);
        }

        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        
        [HttpDelete("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(Messages.ProductDeleted);
            }
            return BadRequest(Messages.ProductIsNotDeleted);
        }

       
        [HttpPut("update")]
        [HttpPatch("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(Messages.ProductUpdated);
            }
            return BadRequest(Messages.ProductIsNotUpdated);
        }
        
    }
}
