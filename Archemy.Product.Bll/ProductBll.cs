﻿using Archemy.Data.Pocos;
using Archemy.Data.Repository.Interfaces;
using Archemy.Helper.Interfaces;
using Archemy.Helper.Models;
using Archemy.Product.Bll.Interfaces;
using Archemy.Product.Bll.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Archemy.Product.Bll
{
    public class ProductBll : IProductBll
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
        /// Initializes a new instance of the <see cref="ProductBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public ProductBll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get Product list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductViewModel> GetList()
        {
            var data = _mapper.Map<IEnumerable<Data.Pocos.Product>, IEnumerable<ProductViewModel>>(
                   _unitOfWork.GetRepository<Data.Pocos.Product>().GetCache());
            var productTypeList = _unitOfWork.GetRepository<ProductType>().GetCache();
            foreach (var item in data)
            {
                var temp = productTypeList.FirstOrDefault(x => x.Id == item.ProductTypeId);
                item.ProductTypeName = temp?.ProductTypeName;
            }
            return data;
        }

        /// <summary>
        /// Get Detail of product item.
        /// </summary>
        /// <param name="id">The identity of Product.</param>
        /// <returns></returns>
        public ProductViewModel GetDetail(int id)
        {
            return _mapper.Map<Data.Pocos.Product, ProductViewModel>(
                   _unitOfWork.GetRepository<Data.Pocos.Product>().GetCache(x => x.Id == id).FirstOrDefault());
        }

        /// <summary>
        /// Insert new Product item.
        /// </summary>
        /// <param name="model">The Product information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(ProductViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var product = _mapper.Map<ProductViewModel, Data.Pocos.Product>(model);
                _unitOfWork.GetRepository<Data.Pocos.Product>().Add(product);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheProduct();
            return result;
        }

        /// <summary>
        /// Update Product item.
        /// </summary>
        /// <param name="model">The Product information value.</param>
        /// <returns></returns>
        public ResultViewModel Edit(ProductViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var product = _unitOfWork.GetRepository<Data.Pocos.Product>().GetCache(x => x.Id == model.Id).FirstOrDefault();
                product.ProductName = model.ProductName;
                product.ProductTypeId = model.ProductTypeId;
                product.Prince1 = model.Prince1;
                product.Prince2 = model.Prince2;
                product.Prince3 = model.Prince3;
                product.Unit = model.Unit;
                _unitOfWork.GetRepository<Data.Pocos.Product>().Update(product);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheProduct();
            return result;
        }

        /// <summary>
        /// Remove Product item.
        /// </summary>
        /// <param name="id">The identity of Product.</param>
        /// <returns></returns>
        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var product = _unitOfWork.GetRepository<Data.Pocos.Product>().GetById(id);
                _unitOfWork.GetRepository<Data.Pocos.Product>().Remove(product);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheProduct();
            return result;
        }

        /// <summary>
        /// Reload Cache when Product is change.
        /// </summary>
        private void ReloadCacheProduct()
        {
            _unitOfWork.GetRepository<Data.Pocos.Product>().ReCache();
        }

        #endregion

    }
}
