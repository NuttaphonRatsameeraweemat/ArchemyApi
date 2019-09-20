﻿using Archemy.Helper.Components;
using Archemy.Helper.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Archemy.Helper
{
    public class ManageToken : IManageToken
    {

        #region [Fields]

        /// <summary>
        /// The httpcontext.
        /// </summary>
        private readonly HttpContext _httpContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageToken" /> class.
        /// </summary>
        /// <param name="httpContextAccessor">The httpcontext value.</param>
        public ManageToken(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get Ad User from payload token.
        /// </summary>
        public string AdUser => _httpContext.User.Identity.Name;
        /// <summary>
        /// Get Full Name from payload token.
        /// </summary>
        public string EmpName => _httpContext.User.Claims.FirstOrDefault(x => x.Type == ConstantValue.ClamisName)?.Value;
        /// <summary>
        /// Get Employee No from payload token.
        /// </summary>
        public string EmpNo => _httpContext.User.Claims.FirstOrDefault(x => x.Type == ConstantValue.ClamisEmpNo)?.Value;
        /// <summary>
        /// Get Encrypt value from payload token.
        /// </summary>
        public string Encrypt => _httpContext.User.Claims.FirstOrDefault(x => x.Type == ConstantValue.ClamisEncrypt)?.Value;
        /// <summary>
        /// Get Org identity value from payload token.
        /// </summary>
        public string OrgId => _httpContext.User.Claims.FirstOrDefault(x => x.Type == ConstantValue.ClamisOrg)?.Value;
        /// <summary>
        /// Get Position identity value from payload token.
        /// </summary>
        public string PositionId => _httpContext.User.Claims.FirstOrDefault(x => x.Type == ConstantValue.ClamisPosition)?.Value;
        /// <summary>
        /// Get Company code value from payload token.
        /// </summary>
        public string ComCode => _httpContext.User.Claims.FirstOrDefault(x => x.Type == ConstantValue.ClamisComCode)?.Value;

        #endregion

    }
}