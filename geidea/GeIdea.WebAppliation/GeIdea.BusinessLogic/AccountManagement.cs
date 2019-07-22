using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GeIdea.Data;
using GeIdea.DataAccess;
using GeIdea.Repository;
using Microsoft.Extensions.Configuration;

namespace GeIdea.BusinessLogic
{
    public class AccountManagement
    {
        private IAccount _accountRepo;
        private readonly IMapper _mapper;
        public AccountManagement(IConfiguration configuration, IMapper mapper)
        {
            _accountRepo =new AccountRepo(configuration,mapper);
            _mapper = mapper;
        }
        
        public void CreateAccount(AccountModel model)
        {
            Account account = new Account()
            {
                AccountId = model.AccountId,
                Email = model.Email,
                Password = model.Password
            };
            _accountRepo.CreateAccount(account);

            _accountRepo.Save();
        }


        public List<AccountModel> GetAccounts()
        {
            IEnumerable<Account> acounts = _accountRepo.GetAccounts().ToList();          
            List<AccountModel> models = _mapper.Map<List<AccountModel>>(acounts);
            return models;
        }

        public AccountModel GetAccount(string email, string password)
        {
           Account account = _accountRepo.GetAccount(email, password);
            AccountModel model = _mapper.Map<AccountModel>(account);
            return model;
        }
    }
}
