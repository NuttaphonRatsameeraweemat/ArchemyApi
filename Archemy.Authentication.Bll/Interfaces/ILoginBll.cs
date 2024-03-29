﻿using Archemy.Authentication.Bll.Models;
using Archemy.Helper.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Archemy.Authentication.Bll.Interfaces
{
    public interface ILoginBll
    {
        /// <summary>
        /// Create and setting payload on token.
        /// </summary>
        /// <param name="principal">The ClaimsPrincipal.</param>
        /// <returns></returns>
        string BuildToken(ClaimsPrincipal principal = null);
        /// <summary>
        /// Validate username and password is valid.
        /// </summary>
        /// <param name="login">The login value.</param>
        /// <returns></returns>
        ResultViewModel Authenticate(LoginViewModel login);
        /// <summary>
        /// Setup response cookie and cookie options token.
        /// </summary>
        /// <param name="httpContext">The HttpContext.</param>
        /// <param name="token">The token value.</param>
        void SetupCookie(HttpContext httpContext, string token);
        /// <summary>
        /// The Method Add ClaimsIdentity Properties.
        /// </summary>
        /// <param name="username">The identity user.</param>
        LoginResponseViewModel ManageClaimsIdentity(LoginViewModel login);
    }
}
