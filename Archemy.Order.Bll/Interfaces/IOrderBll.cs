using Archemy.Helper.Models;
using Archemy.Order.Bll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Order.Bll.Interfaces
{
    public interface IOrderBll
    {
        /// <summary>
        /// Get Order list all by employee identity..
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrderViewModel> GetList();
        /// <summary>
        /// Get Detail of order item.
        /// </summary>
        /// <param name="id">The identity of order.</param>
        /// <returns></returns>
        OrderViewModel GetDetail(int id);
        /// <summary>
        /// Insert new order item.
        /// </summary>
        /// <param name="model">The order information value.</param>
        /// <returns></returns>
        ResultViewModel Save(OrderViewModel model);
        /// <summary>
        /// Get product price contract by account id.
        /// </summary>
        /// <param name="accountId">The identity account.</param>
        /// <returns></returns>
        IEnumerable<OrderDetailViewModel> GetProductContract(int accountId);
    }
}
