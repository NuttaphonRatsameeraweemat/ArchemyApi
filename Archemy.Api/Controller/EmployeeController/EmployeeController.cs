using Archemy.Employee.Bll.Interfaces;
using Archemy.Employee.Bll.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Archemy.Api.Controller.EmployeeController
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The employee manager provides employee functionality.
        /// </summary>
        private readonly IEmployeeBll _employee;

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of the <see cref="RegisterController" /> class.
        /// </summary>
        /// <param name="employee"></param>
        public EmployeeController(IEmployeeBll employee)
        {
            _employee = employee;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            return Ok(_employee.GetList());
        }

        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int id)
        {
            return Ok(_employee.GetDetail(id));
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update([FromBody]EmployeeViewModel model)
        {
            return Ok(_employee.Update(model));
        }

        #endregion

    }
}
