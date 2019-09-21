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
    public class AccountSubTypeController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The account type manager provides account type functionality.
        /// </summary>
        private readonly IAccountSubTypeBll _accountSubType;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="AccountSubTypeController" /> class.
        /// </summary>
        /// <param name="accountSubType"></param>
        public AccountSubTypeController(IAccountSubTypeBll accountSubType)
        {
            _accountSubType = accountSubType;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            return Ok(_accountSubType.GetList());
        }

        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int id)
        {
            return Ok(_accountSubType.GetDetail(id));
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]AccountSubTypeViewModel model)
        {
            return Ok(_accountSubType.Save(model));
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody]AccountSubTypeViewModel model)
        {
            return Ok(_accountSubType.Edit(model));
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_accountSubType.Delete(id));
        }

        #endregion

    }
}
