using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System.Data.Entity;

namespace DAL.Fake.Repositories
{
    /// <summary>
    /// Simple class to work with repository
    /// </summary>
    public class AccountRepository : IRepository<User>
    {

        private UserContext context;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountRepository()
        {
            context = new UserContext();
        }

        /// <summary>
        /// Add account
        /// </summary>
        /// <param name="acc">acc</param>
        public void AddAccount(User acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException();
            }
            context.Set<User>().Add(acc);
            context.SaveChanges();
        }

        /// <summary>
        /// Get account
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>account</returns>
        public User GetAccount(int id)
        {
            return context.Set<User>().Find(id);
        }

        /// <summary>
        /// Remove account
        /// </summary>
        /// <param name="id">id</param>
        public void RemoveAccount(int id)
        {
            User acc = GetAccount(id);

            if (acc != null)
            {
                context.Set<User>().Remove(acc);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public void UpdateAccount(User acc)
        {
            User account = context.Users.First(p => p.U_ID == acc.U_ID);

            account.U_ID = acc.U_ID;
            account.U_NAME = acc.U_NAME;
            account.U_SURNAME = acc.U_SURNAME;
            account.CASH = acc.CASH;
            account.BONUS_POINTS = acc.BONUS_POINTS;
            context.SaveChanges();
        }
    }
}
