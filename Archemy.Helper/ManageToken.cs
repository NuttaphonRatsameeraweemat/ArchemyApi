using Archemy.Helper.Components;
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
        public string Email => _httpContext.User.Identity.Name;
        /// <summary>
        /// Get Employee id from payload token.
        /// </summary>
        public string EmpId => _httpContext.User.Claims.FirstOrDefault(x => x.Type == ConstantValue.ClamisEmployeeId)?.Value;
        /// <summary>
        /// Get Full Name from payload token.
        /// </summary>
        public string EmpName => _httpContext.User.Claims.FirstOrDefault(x => x.Type == ConstantValue.ClamisName)?.Value;

        #endregion

    }
}
