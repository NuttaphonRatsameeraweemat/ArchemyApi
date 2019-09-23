using Archemy.Data.Pocos;
using Archemy.Data.Repository.Interfaces;
using Archemy.Helper.Interfaces;
using Archemy.Helper.Models;
using Archemy.Order.Bll.Interfaces;
using Archemy.Order.Bll.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Archemy.Order.Bll
{
    public class OrderBll : IOrderBll
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
        /// <summary>
        /// The ClaimsIdentity in token management.
        /// </summary>
        private readonly IManageToken _token;

        #endregion

        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public OrderBll(IUnitOfWork unitOfWork, IMapper mapper, IManageToken token)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _token = token;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get Order list all by employee identity..
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderViewModel> GetList()
        {
            return _mapper.Map<IEnumerable<Data.Pocos.Order>, IEnumerable<OrderViewModel>>(
                   _unitOfWork.GetRepository<Data.Pocos.Order>().Get(x => x.EmpId == _token.EmpId));
        }

        /// <summary>
        /// Get Detail of order item.
        /// </summary>
        /// <param name="id">The identity of order.</param>
        /// <returns></returns>
        public OrderViewModel GetDetail(int id)
        {
            var data = _mapper.Map<Data.Pocos.Order, OrderViewModel>(
                   _unitOfWork.GetRepository<Data.Pocos.Order>().Get(x => x.Id == id).FirstOrDefault());
            data.OrderItems = this.GetOrderItems(id).ToList();
            return data;
        }

        private IEnumerable<OrderDetailViewModel> GetOrderItems(int orderId)
        {
            var result = new List<OrderDetailViewModel>();
            var orderItems = _unitOfWork.GetRepository<OrderDetail>().Get(x => x.OrderId == orderId);
            var productList = _unitOfWork.GetRepository<Product>().GetCache();
            foreach (var item in orderItems)
            {
                var temp = productList.FirstOrDefault(x => x.Id == item.Id);
                result.Add(new OrderDetailViewModel
                {
                    Id = item.Id,
                    Prince = item.Prince.Value,
                    PerPrince = item.PerPrince.Value
                });
            }
            return null;
        }

        /// <summary>
        /// Insert new AccountType item.
        /// </summary>
        /// <param name="model">The AccountType information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(OrderViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var accountType = _mapper.Map<OrderViewModel, AccountType>(model);
                _unitOfWork.GetRepository<AccountType>().Add(accountType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheAccountType();
            return result;
        }

        /// <summary>
        /// Update AccountType item.
        /// </summary>
        /// <param name="model">The AccountType information value.</param>
        /// <returns></returns>
        public ResultViewModel Edit(OrderViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var accountType = _unitOfWork.GetRepository<AccountType>().GetCache(x => x.Id == model.Id).FirstOrDefault();
                _unitOfWork.GetRepository<Data.Pocos.AccountType>().Update(accountType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheAccountType();
            return result;
        }

        /// <summary>
        /// Remove AccountType item.
        /// </summary>
        /// <param name="id">The identity of AccountType.</param>
        /// <returns></returns>
        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var accountType = _unitOfWork.GetRepository<AccountType>().GetById(id);
                _unitOfWork.GetRepository<AccountType>().Remove(accountType);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheAccountType();
            return result;
        }

        /// <summary>
        /// Reload Cache when AccountType is change.
        /// </summary>
        private void ReloadCacheAccountType()
        {
            _unitOfWork.GetRepository<AccountType>().ReCache();
        }

        #endregion

    }
}
