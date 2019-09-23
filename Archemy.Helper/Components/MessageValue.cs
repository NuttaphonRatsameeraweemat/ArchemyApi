using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Helper.Components
{
    public static class MessageValue
    {
        public const string UserRoleIsEmpty = "You haven't permission to access.";
        public const string LoginFailed = "Username or Password incorrect.";
        public const string EmailAlreadyExist = "Email is already exits.";
        public const string ContractStatusSubmit = "This contract is submit, your can't edit contract.";
        public const string Unauthorized = "You aren't authorized";
        public const string InternalServerError = "System Error, Please contact admin.";
    }
}
