using Archemy.Employee.Bll.Models;
using Archemy.Product.Bll.Models;
using AutoMapper;

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
            this.MappingProductModel();
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Create auto mapper profile employee model.
        /// </summary>
        public void MappingEmployeeModel()
        {
            CreateMap<RegisterViewModel, Data.Pocos.Employee>();
            CreateMap<Data.Pocos.Employee, RegisterViewModel>();
            CreateMap<EmployeeViewModel, Data.Pocos.Employee>();
            CreateMap<Data.Pocos.Employee, EmployeeViewModel>();
        }

        /// <summary>
        /// Create auto mapper profile product model.
        /// </summary>
        public void MappingProductModel()
        {
            CreateMap<ProductViewModel, Data.Pocos.Product>();
            CreateMap<Data.Pocos.Product, ProductViewModel>();
            CreateMap<ProductTypeViewModel, Data.Pocos.ProductType>();
            CreateMap<Data.Pocos.ProductType, ProductTypeViewModel>();
        }

        #endregion

    }
}
