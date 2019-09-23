using Archemy.Account.Bll.Interfaces;
using Archemy.Data.Pocos;
using Archemy.Data.Repository.Interfaces;
using Archemy.Helper.Components;
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
        /// <summary>
        /// The activityTimeLine manager provides activityTimeLine functionality.
        /// </summary>
        private readonly IActivityTimeLineBll _activityTimeLine;

        #endregion

        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public OrderBll(IUnitOfWork unitOfWork, IMapper mapper, IManageToken token, IActivityTimeLineBll activityTimeLine)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _token = token;
            _activityTimeLine = activityTimeLine;
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

        /// <summary>
        /// Get order detail items information.
        /// </summary>
        /// <param name="orderId">The order identity.</param>
        /// <returns></returns>
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
                    PerPrince = item.PerPrince.Value,
                    ProductId = item.ProductId.Value,
                    ProductName = temp?.ProductName,
                    Quantity = item.Quantity.Value
                });
            }
            return null;
        }

        /// <summary>
        /// Insert new order item.
        /// </summary>
        /// <param name="model">The order information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(OrderViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var order = _mapper.Map<OrderViewModel, Data.Pocos.Order>(model);
                _unitOfWork.GetRepository<Data.Pocos.Order>().Add(order);
                _unitOfWork.Complete(scope);
            }
            _activityTimeLine.Save(new Account.Bll.Models.ActivityTimeLineViewModel { AccountId = model.AccountId, ActivityComment = ConstantValue.ActCreateOrder });
            return result;
        }

        /// <summary>
        /// Insert new order items.
        /// </summary>
        /// <param name="orderId">The order identity.</param>
        /// <param name="model">The order item information value.</param>
        /// <returns></returns>
        private void SaveItem(int orderId, IEnumerable<OrderDetailViewModel> model)
        {
            var orderItems = _mapper.Map<IEnumerable<OrderDetailViewModel>, IEnumerable<OrderDetail>>(model);
            orderItems.Select(c => { c.OrderId = orderId; return c; }).ToList();
            _unitOfWork.GetRepository<OrderDetail>().AddRange(orderItems);
        }

        #endregion

    }
}
