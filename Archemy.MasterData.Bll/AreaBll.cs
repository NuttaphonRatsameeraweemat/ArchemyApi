using Archemy.Data.Pocos;
using Archemy.Data.Repository.Interfaces;
using Archemy.Helper.Models;
using Archemy.MasterData.Bll.Interfaces;
using Archemy.MasterData.Bll.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Archemy.MasterData.Bll
{
    public class AreaBll : IAreaBll
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
        /// Initializes a new instance of the <see cref="AreaBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public AreaBll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get Area list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AreaViewModel> GetList()
        {
            return _mapper.Map<IEnumerable<Area>, IEnumerable<AreaViewModel>>(
                   _unitOfWork.GetRepository<Area>().GetCache());
        }

        /// <summary>
        /// Get Detail of Area item.
        /// </summary>
        /// <param name="id">The identity of Area.</param>
        /// <returns></returns>
        public AreaViewModel GetDetail(int id)
        {
            return _mapper.Map<Area, AreaViewModel>(
                   _unitOfWork.GetRepository<Area>().GetCache(x => x.Id == id).FirstOrDefault());
        }

        /// <summary>
        /// Insert new Area item.
        /// </summary>
        /// <param name="model">The Area information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(AreaViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var Area = _mapper.Map<AreaViewModel, Area>(model);
                _unitOfWork.GetRepository<Area>().Add(Area);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheArea();
            return result;
        }

        /// <summary>
        /// Update Area item.
        /// </summary>
        /// <param name="model">The Area information value.</param>
        /// <returns></returns>
        public ResultViewModel Edit(AreaViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var Area = _unitOfWork.GetRepository<Area>().GetCache(x => x.Id == model.Id).FirstOrDefault();
                Area.AreaName = model.AreaName;
                _unitOfWork.GetRepository<Area>().Update(Area);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheArea();
            return result;
        }

        /// <summary>
        /// Remove Area item.
        /// </summary>
        /// <param name="id">The identity of Area.</param>
        /// <returns></returns>
        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var Area = _unitOfWork.GetRepository<Area>().GetById(id);
                _unitOfWork.GetRepository<Area>().Remove(Area);
                _unitOfWork.Complete(scope);
            }
            this.ReloadCacheArea();
            return result;
        }

        /// <summary>
        /// Reload Cache when Area is change.
        /// </summary>
        private void ReloadCacheArea()
        {
            _unitOfWork.GetRepository<Area>().ReCache();
        }

        #endregion

    }
}
