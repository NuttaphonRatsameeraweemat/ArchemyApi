using Archemy.Account.Bll.Interfaces;
using Archemy.Account.Bll.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archemy.Api.Controller.AccountController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PlanController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The plan manager provides plan functionality.
        /// </summary>
        private readonly IPlanBll _plan;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="PlanController" /> class.
        /// </summary>
        /// <param name="plan"></param>
        public PlanController(IPlanBll plan)
        {
            _plan = plan;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList(int accountId)
        {
            return Ok(_plan.GetList(accountId));
        }
        
        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]PlanViewModel model)
        {
            return Ok(_plan.Save(model));
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody]PlanViewModel model)
        {
            return Ok(_plan.Edit(model));
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_plan.Delete(id));
        }

        #endregion

    }
}
