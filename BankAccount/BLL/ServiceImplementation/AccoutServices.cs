using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using BLL.ServiceImplementation;
using BLL.Interface.Entities;
using AutoMapper;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Simple class to work with bank account
    /// </summary>
    public class AccoutServices : IAccountService
    {
        /// <summary>
        /// DAL worker
        /// </summary>
        IFileWorker FW { get; set; }
        IRepository<User> rep;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fw">DAL</param>
        public AccoutServices(IFileWorker fw, IRepository<User> rep)
        {
            FW = fw;
            this.rep = rep;
        }

        /// <summary>
        /// Deposit money 
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="money">Money</param>
        public void DepositAccount(int id, decimal money)
        {
            var account = FW.Accounts.GetAccount(id);
            if (money <= 0 || account == null || account.A_STATUS == "closed")
            {
                throw new ArgumentException();
            }
            account.CASH += money;
            account.BONUS_POINTS += BonusPoints.GetBonusPoints(account.A_TYPE, money);
            rep.UpdateAccount(account);
        }

        /// <summary>
        /// Withdraw money
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="money">Money</param>
        public void WithdrawAccount(int id, decimal money)
        {
            var account = FW.Accounts.GetAccount(id);
            if (money <= 0 || account == null || account.A_STATUS == "closed")
            {
                throw new ArgumentException();
            }
            account.CASH -= money;
            account.BONUS_POINTS -= BonusPoints.GetBonusPoints(account.A_TYPE, money);
            rep.UpdateAccount(account);
        }

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<BankAccountDTO> GetAllAccounts()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, BankAccountDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<BankAccountDTO>>(FW.Accounts.GetAll());
        }

        /// <summary>
        /// Open account
        /// </summary>
        /// <param name="v">name</param>
        /// <param name="base">type</param>
        /// <param name="id">id</param>
        public void OpenAccount(string v, string @base, int id)
        {
            BankAccountDTO acc = new BankAccountDTO()
            {
                AccountNumber = id,
                FirstName = v,
                AccountType = @base
            };
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BankAccountDTO, User>()).CreateMapper();
            var user = mapper.Map<BankAccountDTO, User>(acc);

            FW.Accounts.AddAccount(user);
        }
    }
}
