using Archemy.Account.Bll.Interfaces;
using Archemy.Account.Bll.Models;
using Archemy.Helper;
using Archemy.Helper.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archemy.Api.Controller.AccountController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ContractController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The contract manager provides contract functionality.
        /// </summary>
        private readonly IContractBll _contract;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="ContractController" /> class.
        /// </summary>
        /// <param name="contract"></param>
        public ContractController(IContractBll contract)
        {
            _contract = contract;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList(int accountId)
        {
            return Ok(_contract.GetList(accountId));
        }

        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int id)
        {
            return Ok(_contract.GetDetail(id));
        }

        [HttpPost]
        [Route("SaveDraft")]
        public IActionResult Save([FromBody]ContractViewModel model)
        {
            return Ok(_contract.Save(model, ConstantValue.ContractStatusSaveDraft));
        }

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit([FromBody]ContractViewModel model)
        {
            IActionResult response;
            if (_contract.IsSubmit(model.Id))
            {
                response = BadRequest(UtilityService.InitialResultError(MessageValue.ContractStatusSubmit, (int)System.Net.HttpStatusCode.BadRequest));
            }
            if (_contract.IsNotNull(model.Id))
            {
                response = Ok(_contract.Edit(model, ConstantValue.ContractStatusSaveSubmit));
            }
            else response = Ok(_contract.Save(model, ConstantValue.ContractStatusSaveSubmit));
            return response;
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody]ContractViewModel model)
        {
            if (_contract.IsSubmit(model.Id))
            {
                return BadRequest(UtilityService.InitialResultError(MessageValue.ContractStatusSubmit, (int)System.Net.HttpStatusCode.BadRequest));
            }
            return Ok(_contract.Edit(model, ConstantValue.ContractStatusSaveDraft));
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_contract.Delete(id));
        }

        #endregion

    }
}
