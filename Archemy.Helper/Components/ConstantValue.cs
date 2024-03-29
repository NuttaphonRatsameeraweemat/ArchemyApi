﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Helper.Components
{
    public static class ConstantValue
    {
        //Claims Type
        public const string ClamisName = "EmpName";
        public const string ClamisEmployeeId = "EmpId";
        //Response Header Content Type Format
        public const string ContentTypeJson = "application/json";
        public const string BasicAuthentication = "BasicAuthentication";
        //Date format
        public const string DateTimeFormat = "yyyy-MM-dd";
        //Template format.
        public const string EmpTemplate = "{0} {1}";
        //ValueType
        public const string ValueTypeEmployeeType = "EmployeeType";
        public const string ValueTypeAccountStatus = "AccountStatus";
        //Regular expresstion format date
        public const string RegexDateFormat = @"^[0-9]{4}-[0-9]{2}-[0-9]{2}$";
        public const string RegexYearFormat = @"^[0-9]{4}$";
        //Contract Status
        public const string ContractStatusSaveDraft = "SaveDraft";
        public const string ContractStatusSaveSubmit = "Submit";
        //Acitivity Timeline system log.
        public const string ActCreateAccount = "Account has been created.";
        public const string ActEditAccount = "Account infomation change.";
        public const string ActCreateContract = "Contract has been created.";
        public const string ActEditContract = "Contract has been change.";
        public const string ActCreateOrder = "Order has been created.";
        //Error Log Messages.
        public const string HrEmployeeArgumentNullExceptionMessage = "The {0} hasn't in HrEmployee Table.";
        public const string HttpRequestFailedMessage = "Response StatusCode {0}, {1}";
        public const string DateIncorrectFormat = "The date value can't be empty and support only 'yyyy-MM-dd' format.";
        public const string YearIncorrectFormat = "The year value can't be empty and support only 'yyyy' format.";
        public const string ArgullmentNullOrEmptyMessage = "parameter can't be null or empty.";
        public const string HttpBadRequestMessage = "The request model is invalid.";
    }
}
