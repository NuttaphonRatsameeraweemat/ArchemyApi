using Archemy.Data.Pocos;
using Archemy.Data.Repository.Interfaces;
using Archemy.MasterData.Bll.Interfaces;
using Archemy.MasterData.Bll.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Archemy.MasterData.Bll
{
    public class ValueHelpBll : IValueHelpBll
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
        /// Initializes a new instance of the <see cref="ValueHelpBll" /> class.
        /// </summary>
        public ValueHelpBll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get ValueHelp List by type.
        /// </summary>
        /// <param name="type">The type of value.</param>
        /// <returns></returns>
        public IEnumerable<ValueHelpViewModel> Get(string type)
        {
            return _mapper.Map<IEnumerable<ValueHelp>, IEnumerable<ValueHelpViewModel>>(
                _unitOfWork.GetRepository<ValueHelp>().GetCache(x => x.ValueType == type, x => x.OrderBy(y => y.Sequence)));
        }

        #endregion
    }
}
