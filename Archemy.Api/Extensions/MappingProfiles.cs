using Archemy.Employee.Bll.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archemy.Api.Extensions
{
    public class MappingProfiles : Profile
    {
        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfiles" /> class.
        /// </summary>
        public MappingProfiles()
        {
            this.MappingEmployeeModel();
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Create auto mapper profile central setting model.
        /// </summary>
        public void MappingEmployeeModel()
        {
            CreateMap<RegisterViewModel, Data.Pocos.Employee>();
            CreateMap<Data.Pocos.Employee, RegisterViewModel>();
            CreateMap<EmployeeViewModel, Data.Pocos.Employee>();
            CreateMap<Data.Pocos.Employee, EmployeeViewModel>();
        }

        #endregion

    }
}
