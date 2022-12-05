using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumirAPICinema2022.Controllers
{
    public class CadastroController : Controller
    {

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CadastroPoltrona()
        {
            return View();
        }


        public IActionResult CadastroSala()
        {
            return View();
        }

        public IActionResult CadastroSexo()
        {
            return View();
        }


        public IActionResult CadastroEmpresa()
        {
            return View();
        }


        public IActionResult CadastroSessao()
        {
            return View();
        }

        public IActionResult CadastroPessoa()
        {
            return View();
        }

        public IActionResult CadastroFuncionario()
        {
            return View();
        }

        public IActionResult CadastroFilme()
        {
            return View();
        }
    }
}
