using Archemy.Order.Bll.Interfaces;
using Archemy.Order.Bll.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archemy.Api.Controller.OrderController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The order manager provides order functionality.
        /// </summary>
        private readonly IOrderBll _order;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="OrderController" /> class.
        /// </summary>
        /// <param name="employee"></param>
        public OrderController(IOrderBll order)
        {
            _order = order;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            return Ok(_order.GetList());
        }

        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int id)
        {
            return Ok(_order.GetDetail(id));
        }

        [HttpGet]
        [Route("GetProductContract")]
        public IActionResult GetProductContract(int accountId)
        {
            return Ok(_order.GetProductContract(accountId));
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]OrderViewModel model)
        {
            return Ok(_order.Save(model));
        }

        #endregion

    }
}
