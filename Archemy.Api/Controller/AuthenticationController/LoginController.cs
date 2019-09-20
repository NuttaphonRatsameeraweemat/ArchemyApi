﻿using Archemy.Authentication.Bll.Interfaces;
using Archemy.Authentication.Bll.Models;
using Archemy.Helper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archemy.Api.Controller.Authentication
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        #region [Fields]

        /// <summary>
        /// The Login manager provides Login functionality.
        /// </summary>
        private readonly ILoginBll _login;

        #endregion

        #region [Constructors]

        /// <summary>
        ///  Initializes a new instance of the <see cref="LoginController" /> class.
        /// </summary>
        /// <param name="login"></param>
        public LoginController(ILoginBll login)
        {
            _login = login;
        }

        #endregion

        #region [Methods]

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody]LoginViewModel auth)
        {
            IActionResult response;
            var result = new ResultViewModel();
            result = _login.Authenticate(auth);
            if (!result.IsError)
            {
                var model = _login.ManageClaimsIdentity(auth);
                string token = _login.BuildToken();
                _login.SetupCookie(HttpContext, token);
                response = Ok(model);
            }
            else response = Unauthorized(result);

            return response;
        }

        #endregion

    }
}
