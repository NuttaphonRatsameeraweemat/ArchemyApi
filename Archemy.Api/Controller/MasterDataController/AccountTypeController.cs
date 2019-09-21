using Archemy.MasterData.Bll.Interfaces;
using Archemy.MasterData.Bll.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Archemy.Api.Controller.MasterDataController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AccountTypeController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The account type manager provides account type functionality.
        /// </summary>
        private readonly IAccountTypeBll _accountType;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="AccountTypeController" /> class.
        /// </summary>
        /// <param name="accountType"></param>
        public AccountTypeController(IAccountTypeBll accountType)
        {
            _accountType = accountType;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            return Ok(_accountType.GetList());
        }

        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int id)
        {
            return Ok(_accountType.GetDetail(id));
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]AccountTypeViewModel model)
        {
            return Ok(_accountType.Save(model));
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody]AccountTypeViewModel model)
        {
            return Ok(_accountType.Edit(model));
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_accountType.Delete(id));
        }

        #endregion

    }
}
