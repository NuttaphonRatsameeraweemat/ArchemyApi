using Archemy.Account.Bll.Interfaces;
using Archemy.Account.Bll.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Archemy.Api.Controller.AccountController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The account manager provides account functionality.
        /// </summary>
        private readonly IAccountBll _account;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="AccountController" /> class.
        /// </summary>
        /// <param name="account"></param>
        public AccountController(IAccountBll account)
        {
            _account = account;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            return Ok(_account.GetList());
        }

        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int id)
        {
            return Ok(_account.GetDetail(id));
        }

        [HttpGet]
        [Route("GetAccountProductOrder")]
        public IActionResult GetAccountProductOrder(int accountId)
        {
            return Ok(_account.GetProductAccountSell(accountId));
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]AccountViewModel model)
        {
            return Ok(_account.Save(model));
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody]AccountViewModel model)
        {
            return Ok(_account.Edit(model));
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_account.Delete(id));
        }

        #endregion

    }
}
