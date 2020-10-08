using System;
using System.Collections.Generic;
using System.Linq;
using Teleagendamento.Libraries.Banco.Contexto;
using Teleagendamento.Libraries.Banco.Repositorio.Interface;
using Teleagendamento.Models;
using Teleagendamento.Models.Enum;
using X.PagedList;

namespace Teleagendamento.Libraries.Banco.Repositorio
{
    public class ClinicaRepositorio : IClinicaRepositorio
    {
        private readonly TeleatendimentoContext _banco;
        private readonly int _registrosPorPagina = 10;
        public ClinicaRepositorio(TeleatendimentoContext banco)
        {
            _banco = banco;
        }
        public bool Atualizar(Clinica registro)
        {
            try
            {
                _banco.Update(registro);
                _banco.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Excluir(int id)
        {
            Clinica registro = _banco.Clinica.Find(id);
            try
            {
                _banco.Remove(registro);
                _banco.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Existe(int id, string nome, TipoStatus status)
        {
            bool existe = false;
            if (id > 0)
            {
                existe = _banco.Clinica.Any(x => x.Id == id);
            }
            if (!existe && !string.IsNullOrEmpty(nome) && !string.IsNullOrWhiteSpace(nome))
            {
                existe = _banco.Clinica.Any(x => x.Nome.Equals(nome));
            }
            if (status != TipoStatus.Todos)
            {
                existe = _banco.Clinica.Any(x => x.Status == status);
            }
            return existe;
        }

        public bool Existe(Clinica registro)
        {
            bool existe = false;
            existe = _banco.Clinica.Contains(registro);
            return existe;
        }

        public List<Clinica> Listar(int id, string nome, string cnpj, TipoStatus status)
        {
            var query = _banco.Clinica.AsQueryable();
            if (id > 0)
            {
                query = query.Where(x => x.Id == id);
            }
            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrWhiteSpace(nome))
            {
                query = query.Where(x => x.Nome.Equals(nome));
            }
            if (!string.IsNullOrEmpty(cnpj) && !string.IsNullOrWhiteSpace(cnpj))
            {
                query = query.Where(x => x.CNPJ.Equals(cnpj));
            }
            if (status != TipoStatus.Todos)
            {
                query = query.Where(x => x.Status == status);
            }
            var registro = new List<Clinica>();
            try
            {
                registro = query.ToList();
            }
            catch (Exception ex)
            {
                //TODO: Log
                return new List<Clinica>();
            }

            return registro;
        }

        public Clinica Obter(int id)
        {
            bool existe = Existe(id, string.Empty, TipoStatus.Todos);
            Clinica registro = null;

            try
            {
                if (existe)
                {
                    registro = _banco.Clinica.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return registro;
        }


        public IPagedList<Clinica> ObterTodas(int? pagina)
        {
            int numeroPagina = pagina ?? 1;
            var lista = _banco.Clinica.ToPagedList<Clinica>(numeroPagina, _registrosPorPagina);
            return lista;
        }

        public bool Salvar(Clinica registro)
        {
            if (!Existe(registro))
            {
                _banco.Add(registro);

                try
                {
                    _banco.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                Atualizar(registro);
            }
            return true;
        }
    }
}
