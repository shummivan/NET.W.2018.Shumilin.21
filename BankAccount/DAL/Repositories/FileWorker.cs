using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System.IO;
using DAL.Fake.Repositories;
using DAL.Fake;

namespace DAL.Repositories
{
    /// <summary>
    /// Simple class to work with data
    /// </summary>
    public class FileWorker : IFileWorker
    {
        /// <summary>
        /// Path
        /// </summary>
        private string path;
        UserContext db = new UserContext();

        /// <summary>
        /// Repository
        /// </summary>
        private AccountRepository rep;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paths">Paths</param>
        public FileWorker(string paths)
        {
            path = paths ?? throw new ArgumentNullException();
            if (!File.Exists(paths))
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Accounts
        /// </summary>
        public IRepository<User> Accounts
        {
            get
            {
                if (rep == null)
                {
                    rep = new AccountRepository();
                }
                return rep;
            }

        }
    }
}
