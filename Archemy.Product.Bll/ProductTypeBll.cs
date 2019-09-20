using Archemy.Data.Repository.Interfaces;
using Archemy.Product.Bll.Models;
using Archemy.Product.Bll.Interfaces;
using Archemy.Data.Pocos;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Archemy.Helper.Models;
using System.Transactions;

namespace Archemy.Product.Bll
{
    public class ProductTypeBll : IProductTypeBll
    {

        #region [Fields]

        /// <summary>
        /// The utilities unit of work for manipulating utilities data in database.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// The auto mapper.
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public ProductTypeBll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get ProductType list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductTypeViewModel> GetList()
        {
            return _mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeViewModel>>(
                   _unitOfWork.GetRepository<ProductType>().GetCache());
        }

        /// <summary>
        /// Get Detail of ProductType item.
        /// </summary>
        /// <param name="id">The identity of ProductType.</param>
        /// <returns></returns>
        public ProductTypeViewModel GetDetail(int id)
        {
            return _mapper.Map<ProductType, ProductTypeViewModel>(
                   _unitOfWork.GetRepository<ProductType>().GetCache(x => x.Id == id).FirstOrDefault());
        }

        /// <summary>
        /// Insert new ProductType item.
        /// </summary>
        /// <param name="model">The ProductType information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(ProductTypeViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var productType = _mapper.Map<ProductTypeViewModel, ProductType>(model);
                _unitOfWork.GetRepository<ProductType>().Add(productType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheProductType();
            return result;
        }

        /// <summary>
        /// Update ProductType item.
        /// </summary>
        /// <param name="model">The ProductType information value.</param>
        /// <returns></returns>
        public ResultViewModel Edit(ProductTypeViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var productType = _unitOfWork.GetRepository<ProductType>().GetCache(x => x.Id == model.Id).FirstOrDefault();
                productType.ProductTypeName = model.ProductTypeName;
                _unitOfWork.GetRepository<ProductType>().Update(productType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheProductType();
            return result;
        }

        /// <summary>
        /// Remove ProductType item.
        /// </summary>
        /// <param name="id">The identity of ProductType.</param>
        /// <returns></returns>
        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var productType = _unitOfWork.GetRepository<ProductType>().GetById(id);
                _unitOfWork.GetRepository<ProductType>().Remove(productType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheProductType();
            return result;
        }

        /// <summary>
        /// Reload Cache when ProductType is change.
        /// </summary>
        private void ReloadCacheProductType()
        {
            _unitOfWork.GetRepository<ProductType>().ReCache();
        }

        #endregion

    }
}
