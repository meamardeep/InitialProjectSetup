using Microsoft.Extensions.Configuration;
using System;
using GeIdea.Repository;
using GeIdea.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace GeIdea.Repository
{
    public class AccountRepo : IAccount,IDisposable
    {
        private GeIdeaDataContext _database;
        //private readonly IMapper _mapper;

        public AccountRepo(IConfiguration configuration, IMapper _mapper)
        {
            _database = new GeIdeaDataContext(configuration);
        }

        #region Account CRUD Repo
       
        public IEnumerable<Account> GetAccounts()
        {
            var sql = from a in _database.Accounts
                      select a;
            return sql;
        }

        public Account GetAccount(string email, string password)
        {
            var sql= (from a in _database.Accounts
                    where a.Email == email && a.Password == password
                    select a).ToList();

            return sql.Count()>0 ? sql.FirstOrDefault(): new Account();
        }

        public void CreateAccount(Account account)
        {
            _database.Accounts.Add(account);
        }
        #endregion

        #region Save Logic
        public void Save()
        {
            _database.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _database.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
