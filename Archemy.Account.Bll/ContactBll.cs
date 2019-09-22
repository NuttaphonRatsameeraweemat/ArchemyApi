using Archemy.Account.Bll.Models;
using Archemy.Account.Bll.Interfaces;
using Archemy.Data.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Archemy.Helper.Models;
using System.Transactions;
using System.Linq;

namespace Archemy.Account.Bll
{
    public class ContactBll : IContactBll
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
        /// Initializes a new instance of the <see cref="ContactBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public ContactBll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get Contact list with account.
        /// </summary>
        /// <param name="accountId">The account identity.</param>
        /// <returns></returns>
        public IEnumerable<ContactViewModel> GetListByAccount(int accountId)
        {
            return _mapper.Map<IEnumerable<Data.Pocos.Contact>, IEnumerable<ContactViewModel>>(
                   _unitOfWork.GetRepository<Data.Pocos.Contact>().Get(x => x.AccountId == accountId)); ;
        }

        /// <summary>
        /// Insert new Contact item.
        /// </summary>
        /// <param name="model">The Contact information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(ContactViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var contact = _mapper.Map<ContactViewModel, Data.Pocos.Contact>(model);
                _unitOfWork.GetRepository<Data.Pocos.Contact>().Add(contact);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        /// <summary>
        /// Update Contact item.
        /// </summary>
        /// <param name="model">The ContactType information value.</param>
        /// <returns></returns>
        public ResultViewModel Edit(ContactViewModel model)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var contact = _unitOfWork.GetRepository<Data.Pocos.Contact>().GetById(model.Id);
                contact.ContactName = model.ContactName;
                contact.ContactNumber = model.ContactNumber;
                contact.Position = model.Position;
                contact.WhoesaleSupplier = model.WhoesaleSupplier;
                _unitOfWork.GetRepository<Data.Pocos.Contact>().Update(contact);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        /// <summary>
        /// Remove Contact item.
        /// </summary>
        /// <param name="id">The identity of Contact.</param>
        /// <returns></returns>
        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var contact = _unitOfWork.GetRepository<Data.Pocos.Contact>().GetById(id);
                _unitOfWork.GetRepository<Data.Pocos.Contact>().Remove(contact);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        #endregion

    }
}
