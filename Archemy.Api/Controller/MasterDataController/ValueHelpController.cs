using Archemy.Helper.Components;
using Archemy.MasterData.Bll.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Archemy.Api.Controller.MasterDataController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ValueHelpController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The value help manager provides value help functionality.
        /// </summary>
        private readonly IValueHelpBll _valueHelp;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="ValueHelpController" /> class.
        /// </summary>
        /// <param name="valueHelp"></param>
        public ValueHelpController(IValueHelpBll valueHelp)
        {
            _valueHelp = valueHelp;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetEmployeeType")]
        public IActionResult GetTicketStatus()
        {
            return Ok(_valueHelp.Get(ConstantValue.ValueTypeEmployeeType));
        }

        [HttpGet]
        [Route("GetAccountStatus")]
        public IActionResult GetAccountStatus()
        {
            return Ok(_valueHelp.Get(ConstantValue.ValueTypeAccountStatus));
        }

        #endregion

    }
}
