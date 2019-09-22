using Archemy.Account.Bll.Interfaces;
using Archemy.Account.Bll.Models;
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
    public class ActivityTimeLineController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The activity timeLine manager provides activity timeLine functionality.
        /// </summary>
        private readonly IActivityTimeLineBll _activityTimeline;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="ActivityTimeLineController" /> class.
        /// </summary>
        /// <param name="activityTimeline"></param>
        public ActivityTimeLineController(IActivityTimeLineBll activityTimeline)
        {
            _activityTimeline = activityTimeline;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList(int accountId)
        {
            return Ok(_activityTimeline.GetList(accountId));
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody]ActivityTimeLineViewModel model)
        {
            return Ok(_activityTimeline.Save(model));
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit([FromBody]ActivityTimeLineViewModel model)
        {
            return Ok(_activityTimeline.Edit(model));
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_activityTimeline.Delete(id));
        }

        #endregion

    }
}
