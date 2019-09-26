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
        /// Get list product filter by product type id.
        /// </summary>
        /// <param name="productTypeId">The product type identity.</param>
        /// <returns></returns>
        IEnumerable<ProductViewModel> GetListByProductType(int productTypeId);
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
        /// <summary>
        /// Write images file to server directory.
        /// </summary>
        /// <param name="imageList">The images model collection.</param>
        /// <param name="productId">The images product identity.</param>
        ResultViewModel SaveImages(IEnumerable<ProductImageViewModel> imageList, int productId);
        /// <summary>
        /// Get images from product id.
        /// </summary>
        /// <param name="id">The identity product.</param>
        /// <returns></returns>
        IEnumerable<ProductImageViewModel> GetProductImages(int id);
    }
}
