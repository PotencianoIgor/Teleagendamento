using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teleagendamento.Libraries.Banco.Contexto;
using Teleagendamento.Libraries.Banco.Repositorio.Interface;
using Teleagendamento.Models;
using X.PagedList;

namespace Teleagendamento.Libraries.Banco.Repositorio
{

    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly TeleatendimentoContext _banco;
        private readonly int _registrosPorPagina = 10;

        public EnderecoRepositorio(TeleatendimentoContext banco)
        {
            _banco = banco;
        }

        public bool Atualizar(Endereco registro)
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
            Endereco registro = _banco.Endereco.Find(id);
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

        public bool Existe(int id)
        {
            bool existe = false;
            if (id > 0)
            {
                existe = _banco.Clinica.Any(x => x.Id == id);
            }
            return existe;
        }

        public bool Existe(Endereco registro)
        {
            bool existe = false;
            existe = _banco.Endereco.Contains(registro);
            return existe;
        }

        public List<Endereco> Listar(int id, string cep)
        {
            var query = _banco.Endereco.AsQueryable();
            if (id > 0)
            {
                query = query.Where(x => x.Id == id);
            }
            if (!string.IsNullOrEmpty(cep) && !string.IsNullOrWhiteSpace(cep))
            {
                query = query.Where(x => x.CEP.Equals(cep));
            }
            var registro = new List<Endereco>();
            try
            {
                registro = query.ToList();
            }
            catch (Exception ex)
            {
                //TODO: Log
                return new List<Endereco>();
            }

            return registro;
        }

        public Endereco Obter(int id)
        {
            bool existe = Existe(id);
            Endereco registro = null;

            try
            {
                if (existe)
                {
                    registro = _banco.Endereco.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return registro;
        }

        public IPagedList<Endereco> ObterTodas(int? pagina)
        {
            int numeroPagina = pagina ?? 1;
            var lista = _banco.Endereco.ToPagedList<Endereco>(numeroPagina, _registrosPorPagina);
            return lista;
        }

        public bool Salvar(Endereco registro)
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
            return true;
        }
    }
}
