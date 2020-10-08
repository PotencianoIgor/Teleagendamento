using Microsoft.AspNetCore.Mvc;
using Teleagendamento.Libraries.Banco.Repositorio.Interface;

namespace Teleagendamento.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly IClinicaRepositorio _clinicaRepositorio;

        public AgendamentoController(IClinicaRepositorio clinicaRepositorio)
        {
            _clinicaRepositorio = clinicaRepositorio;
        }
        public IActionResult Index()
        {
            var lista = _clinicaRepositorio.ObterTodas(null);
            TempData["Lista_Clinicas"] = lista;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Models.Filtro.ClinicaFilter filtro)
        {
            var lista = _clinicaRepositorio.Listar(0, filtro.Nome, filtro.CNPJ, filtro.Status);
            TempData["Lista_Clinicas"] = lista;
            ViewData["Area_Filtro_Expandida"] = true;
            return View(filtro);
        }

        public IActionResult ExibirAgenda()
        {
            return View("_Schedule");
        }
    }
}