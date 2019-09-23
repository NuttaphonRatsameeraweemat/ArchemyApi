using Archemy.Account.Bll.Models;
using Archemy.Employee.Bll.Models;
using Archemy.MasterData.Bll.Models;
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
            this.MappingMasterDataModel();
            this.MappingAccountModel();
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
        /// Create auto mapper profile master data model.
        /// </summary>
        public void MappingMasterDataModel()
        {
            CreateMap<AccountTypeViewModel, Data.Pocos.AccountType>();
            CreateMap<Data.Pocos.AccountType, AccountTypeViewModel>();
            CreateMap<AccountSubTypeViewModel, Data.Pocos.AccountSubType>();
            CreateMap<Data.Pocos.AccountSubType, AccountSubTypeViewModel>();
            CreateMap<AreaViewModel, Data.Pocos.Area>();
            CreateMap<Data.Pocos.Area, AreaViewModel>();
            CreateMap<ValueHelpViewModel, Data.Pocos.ValueHelp>();
            CreateMap<Data.Pocos.ValueHelp, ValueHelpViewModel>();
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

        /// <summary>
        /// Create auto mapper profile account model.
        /// </summary>
        public void MappingAccountModel()
        {
            CreateMap<AccountViewModel, Data.Pocos.Account>();
            CreateMap<Data.Pocos.Account, AccountViewModel>();
            CreateMap<ContactViewModel, Data.Pocos.Contact>();
            CreateMap<Data.Pocos.Contact, ContactViewModel>();
            CreateMap<ContractViewModel, Data.Pocos.Contract>();
            CreateMap<Data.Pocos.Contract, ContractViewModel>();
            CreateMap<ActivityTimeLineViewModel, Data.Pocos.ActivityTimeLine>();
            CreateMap<Data.Pocos.ActivityTimeLine, ActivityTimeLineViewModel>();
            CreateMap<PlanViewModel, Data.Pocos.Plan>();
            CreateMap<Data.Pocos.Plan, PlanViewModel>();
        }

        #endregion

    }
}
