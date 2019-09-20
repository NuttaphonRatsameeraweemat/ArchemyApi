using Archemy.Employee.Bll.Interfaces;
using Archemy.Employee.Bll.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archemy.Api.Controller.EmployeeController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class RegisterController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The Register manager provides Register functionality.
        /// </summary>
        private readonly IRegisterBll _register;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="RegisterController" /> class.
        /// </summary>
        /// <param name="register"></param>
        public RegisterController(IRegisterBll register)
        {
            _register = register;
        }

        #endregion

        #region Methods

        [HttpPost]
        public IActionResult Register([FromBody]RegisterViewModel formData)
        {
            IActionResult actionResult;
            var result = _register.Register(formData);
            if (result.IsError)
            {
                actionResult = Conflict(result);
            }
            else actionResult = Ok(result);
            return actionResult;
        }

        [HttpPost]
        [Route("ValidateEmail")]
        public IActionResult ValidateEmail([FromBody]string email)
        {
            IActionResult actionResult;
            var result = _register.ValidateEmail(email);
            if (result.IsError)
            {
                actionResult = Conflict(result);
            }
            else actionResult = Ok(result);
            return actionResult;
        }

        #endregion

    }
}
