using Archemy.Helper.Models;
using Archemy.Product.Bll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Product.Bll.Interfaces
{
    public interface IProductTypeBll
    {
        /// <summary>
        /// Get ProductType list.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductTypeViewModel> GetList();
        /// <summary>
        /// Get Detail of ProductType item.
        /// </summary>
        /// <param name="id">The identity of ProductType.</param>
        /// <returns></returns>
        ProductTypeViewModel GetDetail(int id);
        /// <summary>
        /// Insert new ProductType item.
        /// </summary>
        /// <param name="model">The ProductType information value.</param>
        /// <returns></returns>
        ResultViewModel Save(ProductTypeViewModel model);
        /// <summary>
        /// Update ProductType item.
        /// </summary>
        /// <param name="model">The ProductType information value.</param>
        /// <returns></returns>
        ResultViewModel Edit(ProductTypeViewModel model);
        /// <summary>
        /// Remove ProductType item.
        /// </summary>
        /// <param name="id">The identity of ProductType.</param>
        /// <returns></returns>
        ResultViewModel Delete(int id);
    }
}
