using Archemy.Account.Bll.Interfaces;
using Archemy.Account.Bll.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Archemy.Api.Controller.AccountController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The contact manager provides contact functionality.
        /// </summary>
        private readonly IContactBll _contact;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="ContactController" /> class.
        /// </summary>
        /// <param name="contact"></param>
        public ContactController(IContactBll contact)
        {
            _contact = contact;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetListByAccount")]
        public IActionResult GetListByAccount(int accountId)
        {
            return Ok(_contact.GetListByAccount(accountId));
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]ContactViewModel model)
        {
            return Ok(_contact.Save(model));
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody]ContactViewModel model)
        {
            return Ok(_contact.Edit(model));
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_contact.Delete(id));
        }

        #endregion

    }
}
