using Archemy.Product.Bll.Interfaces;
using Archemy.Product.Bll.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Archemy.Api.Controller.ProductController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProductTypeController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The product type manager provides product type functionality.
        /// </summary>
        private readonly IProductTypeBll _productType;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="ProductTypeController" /> class.
        /// </summary>
        /// <param name="productType"></param>
        public ProductTypeController(IProductTypeBll productType)
        {
            _productType = productType;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            return Ok(_productType.GetList());
        }

        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int id)
        {
            return Ok(_productType.GetDetail(id));
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]ProductTypeViewModel model)
        {
            return Ok(_productType.Save(model));
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody]ProductTypeViewModel model)
        {
            return Ok(_productType.Edit(model));
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_productType.Delete(id));
        }

        #endregion

    }
}
