using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Teleagendamento.Libraries.Banco.Repositorio.Interface;
using Teleagendamento.Models;

namespace Teleagendamento.Controllers
{
    public class ClinicaController : Controller
    {
        private readonly IClinicaRepositorio _clinicaRepositorio;

        public ClinicaController(IClinicaRepositorio clinicaRepositorio)
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

        [HttpPost]
        public IActionResult Cadastro([FromForm] Clinica model)
        {
            var listaMensagens = new List<ValidationResult>();
            var contexto = new System.ComponentModel.DataAnnotations.ValidationContext(model);
            bool clienteValido = Validator.TryValidateObject(model, contexto, listaMensagens, true);
            if (ModelState.IsValid && clienteValido)
            {
                _clinicaRepositorio.Salvar(model);

                TempData["MSG_SUCESSO"] = "Registro salvo com sucesso!";
                RedirectToAction(nameof(Cadastro));
            }
            else
            {
                TempData["MSG_ERRO"] = "Não foi possível salvar! verifique se os campos foram preenchidos corretamente!";
            }

            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int id = 0)
        {
            Clinica model = new Clinica();
            if (id > 0)
            {
                model =  _clinicaRepositorio.Obter(id);
                if (model == null)
                {
                    return NotFound();
                }
            }
            return View(model);
        }
    }
}