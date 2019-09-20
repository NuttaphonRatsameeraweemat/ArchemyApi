using Archemy.Helper.Models;
using Archemy.Product.Bll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archemy.Product.Bll.Interfaces
{
    public interface IProductBll
    {
        /// <summary>
        /// Get Product list.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductViewModel> GetList();
        /// <summary>
        /// Get Detail of product item.
        /// </summary>
        /// <param name="id">The identity of Product.</param>
        /// <returns></returns>
        ProductViewModel GetDetail(int id);
        /// <summary>
        /// Insert new Product item.
        /// </summary>
        /// <param name="model">The Product information value.</param>
        /// <returns></returns>
        ResultViewModel Save(ProductViewModel model);
        /// <summary>
        /// Update Product item.
        /// </summary>
        /// <param name="model">The Product information value.</param>
        /// <returns></returns>
        ResultViewModel Edit(ProductViewModel model);
        /// <summary>
        /// Remove Product item.
        /// </summary>
        /// <param name="id">The identity of Product.</param>
        /// <returns></returns>
        ResultViewModel Delete(int id);
    }
}
