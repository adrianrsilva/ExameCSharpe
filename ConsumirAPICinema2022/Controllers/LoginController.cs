using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumirCinema2022.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginFuncionario()
        {
            return View();
        }
        public IActionResult HomeLogin()
        {
            return View();
        }
    }
}
