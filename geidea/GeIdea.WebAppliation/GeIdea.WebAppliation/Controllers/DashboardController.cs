﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GeIdea.Presentation
{
    public class DashboardController : Controller
    {
       
        public DashboardController(IConfiguration configuration)
        {
           
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}