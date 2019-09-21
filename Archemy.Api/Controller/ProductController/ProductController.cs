using Archemy.Product.Bll.Interfaces;
using Archemy.Product.Bll.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace Archemy.Api.Controller.ProductController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The product manager provides product functionality.
        /// </summary>
        private readonly IProductBll _product;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="ProductController" /> class.
        /// </summary>
        /// <param name="employee"></param>
        public ProductController(IProductBll product)
        {
            _product = product;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            return Ok(_product.GetList());
        }

        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int id)
        {
            return Ok(_product.GetDetail(id));
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]ProductViewModel model)
        {
            return Ok(_product.Save(model));
        }

        [HttpGet]
        [Route("GetProductImages")]
        public IActionResult GetProductImages(int id)
        {
            return Ok(_product.GetProductImages(id));
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody]ProductViewModel model)
        {
            return Ok(_product.Edit(model));
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_product.Delete(id));
        }

        [HttpPost]
        [Route("UploadImages/{id}")]
        public IActionResult UploadImages(int id, [FromBody]IEnumerable<ProductImageViewModel> model)
        {
            return Ok(_product.SaveImages(model, id));
        }

        #endregion

    }
}
