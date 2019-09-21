using Archemy.MasterData.Bll.Interfaces;
using Archemy.MasterData.Bll.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archemy.Api.Controller.MasterDataController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AreaController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The area manager provides area functionality.
        /// </summary>
        private readonly IAreaBll _area;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="AreaController" /> class.
        /// </summary>
        /// <param name="Area"></param>
        public AreaController(IAreaBll area)
        {
            _area = area;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            return Ok(_area.GetList());
        }

        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int id)
        {
            return Ok(_area.GetDetail(id));
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]AreaViewModel model)
        {
            return Ok(_area.Save(model));
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody]AreaViewModel model)
        {
            return Ok(_area.Edit(model));
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_area.Delete(id));
        }

        #endregion

    }
}
