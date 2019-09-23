using Archemy.Account.Bll.Interfaces;
using Archemy.Account.Bll.Models;
using Archemy.Data.Repository.Interfaces;
using Archemy.Helper.Components;
using Archemy.Helper.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Archemy.Account.Bll
{
    public class ContractBll : IContractBll
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
        /// Initializes a new instance of the <see cref="ContractBll" /> class.
        /// </summary>
        /// <param name="unitOfWork">The utilities unit of work.</param>
        /// <param name="mapper">The auto mapper.</param>
        public ContractBll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Get Contract list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContractViewModel> GetList(int accountId)
        {
            return _mapper.Map<IEnumerable<Data.Pocos.Contract>, IEnumerable<ContractViewModel>>(
                   _unitOfWork.GetRepository<Data.Pocos.Contract>().Get(x => x.AccountId == accountId));
        }

        /// <summary>
        /// Get Detail of Contract item.
        /// </summary>
        /// <param name="id">The identity of Contract.</param>
        /// <returns></returns>
        public ContractViewModel GetDetail(int id)
        {
            var data = _mapper.Map<Data.Pocos.Contract, ContractViewModel>(
                   _unitOfWork.GetRepository<Data.Pocos.Contract>().Get(x => x.Id == id).FirstOrDefault());
            var productList = _unitOfWork.GetRepository<Data.Pocos.Product>().GetCache();
            var contractItem = _unitOfWork.GetRepository<Data.Pocos.ContractItem>().Get(x => x.ContractId == data.Id);
            data.ContractItems = _mapper.Map<List<Data.Pocos.ContractItem>, List<ContractItemViewModel>>(
                   _unitOfWork.GetRepository<Data.Pocos.ContractItem>().Get(x => x.ContractId == data.Id).ToList());
            foreach (var item in data.ContractItems)
            {
                var temp = productList.FirstOrDefault(x => x.Id == item.ProductId);
                item.ProductName = temp.ProductName;
            }

            return data;
        }

        /// <summary>
        /// Validate contract is submit or saveDraft.
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        public bool IsSubmit(int contractId)
        {
            bool result = false;
            var data = _unitOfWork.GetRepository<Data.Pocos.Contract>().GetById(contractId);
            if (data.Status == ConstantValue.ContractStatusSaveSubmit)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Validate contract is null or not.
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        public bool IsNotNull(int contractId)
        {
            bool result = false;
            var data = _unitOfWork.GetRepository<Data.Pocos.Contract>().GetById(contractId);
            if (data != null)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Insert new Contract item.
        /// </summary>
        /// <param name="model">The Contract information value.</param>
        /// <returns></returns>
        public ResultViewModel Save(ContractViewModel model, string status)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var contract = _mapper.Map<ContractViewModel, Data.Pocos.Contract>(model);
                contract.Status = status;
                _unitOfWork.GetRepository<Data.Pocos.Contract>().Add(contract);
                _unitOfWork.Complete();
                this.SaveItem(contract.Id, model.ContractItems);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        /// <summary>
        /// Insert new Contract item.
        /// </summary>
        /// <param name="contractId">The contract identity.</param>
        /// <param name="model">The Contract item information value.</param>
        /// <returns></returns>
        private void SaveItem(int contractId, IEnumerable<ContractItemViewModel> model)
        {
            var contractItems = _mapper.Map<IEnumerable<ContractItemViewModel>, IEnumerable<Data.Pocos.ContractItem>>(model);
            contractItems.Select(c => { c.ContractId = contractId; return c; }).ToList();
            _unitOfWork.GetRepository<Data.Pocos.ContractItem>().AddRange(contractItems);
        }

        /// <summary>
        /// Update Contract item.
        /// </summary>
        /// <param name="model">The ContractType information value.</param>
        /// <returns></returns>
        public ResultViewModel Edit(ContractViewModel model, string status)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var contract = _unitOfWork.GetRepository<Data.Pocos.Contract>().Get(x => x.Id == model.Id).FirstOrDefault();
                contract.Contract1 = model.Contract1;
                contract.MainContract = model.MainContract;
                contract.StartDate = model.StartDate;
                contract.EndDate = model.EndDate;
                contract.Status = status;
                _unitOfWork.GetRepository<Data.Pocos.Contract>().Update(contract);
                this.EditItem(contract.Id, model.ContractItems);
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        /// <summary>
        /// Update contract items list.
        /// </summary>
        /// <param name="contractId">The contract identity.</param>
        /// <param name="model">The contract items.</param>
        private void EditItem(int contractId, IEnumerable<ContractItemViewModel> model)
        {
            var data = _unitOfWork.GetRepository<Data.Pocos.ContractItem>().Get(x => x.ContractId == contractId);

            var contractItemAdd = model.Where(x => x.Id == 0);
            var contractItemDelete = data.Where(x => !data.Any(y => x.Id == y.Id));

            var contractItemUpdate = _mapper.Map<IEnumerable<ContractItemViewModel>, IEnumerable<Data.Pocos.ContractItem>>(model);
            contractItemUpdate = contractItemUpdate.Where(x => data.Any(y => x.Id == y.Id));

            this.SaveItem(contractId, contractItemAdd);
            this.DeleteItem(contractItemDelete);
            _unitOfWork.GetRepository<Data.Pocos.ContractItem>().UpdateRange(contractItemUpdate);
        }

        /// <summary>
        /// Remove Contract item.
        /// </summary>
        /// <param name="accountId">The identity of Contract.</param>
        /// <returns></returns>
        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            using (TransactionScope scope = new TransactionScope())
            {
                var contract = _unitOfWork.GetRepository<Data.Pocos.Contract>().GetById(id);
                _unitOfWork.GetRepository<Data.Pocos.Contract>().Remove(contract);
                this.DeleteItem(_unitOfWork.GetRepository<Data.Pocos.ContractItem>().Get(x => x.ContractId == contract.Id));
                _unitOfWork.Complete(scope);
            }
            return result;
        }

        /// <summary>
        /// Remove Contract item.
        /// </summary>
        /// <param name="items">The contract items collection.</param>
        /// <returns></returns>
        public void DeleteItem(IEnumerable<Data.Pocos.ContractItem> items)
        {
            _unitOfWork.GetRepository<Data.Pocos.ContractItem>().RemoveRange(items);
        }

        #endregion

    }
}
