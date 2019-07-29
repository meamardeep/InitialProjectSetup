using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeIdea.Data;
using GeIdea.BusinessLogic;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace GeIdea.Presentation
{
    public class AccountController : Controller
    {
        private AccountManagement _accountManagement;
        //private readonly IMapper _mapper;
        public AccountController(IConfiguration configuration , IMapper mapper)
        {
            _accountManagement = new AccountManagement(configuration,mapper);
        }

        public IActionResult Index()
        {
            AccountModel model = new AccountModel() { Email = "deepamar@gmail.com ", Password = "master2019" };
            return View("~/Views/Account/LogOn.cshtml",model);
        }
      
        public IActionResult DoLogon([FromBody]AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Account/Index.cshtml");
            }

            AccountModel accountModel = _accountManagement.GetAccount(model.Email, model.Password);
            if (accountModel.AccountId > 0)
            {
                return View("~/Views/Dashboard/Index.cshtml");
                //return RedirectToAction("index", "dashboard");
            }
            else
            {
                return View("~/Views/Account/Index.cshtml");

            }
        }

        
    }
}