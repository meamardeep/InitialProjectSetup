using System;
using System.Collections.Generic;
using System.Text;
using GeIdea.DataAccess;

namespace GeIdea.Repository
{
    public interface IAccount
    {
        #region Account Interface
        IEnumerable<Account> GetAccounts();
        Account GetAccount(string email, string password);
        void CreateAccount(Account account);
        #endregion

        void Save();
    }
}
