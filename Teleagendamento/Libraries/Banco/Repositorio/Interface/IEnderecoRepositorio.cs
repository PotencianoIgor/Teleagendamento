using System.Collections.Generic;
using Teleagendamento.Models;
using X.PagedList;

namespace Teleagendamento.Libraries.Banco.Repositorio.Interface
{
    public interface IEnderecoRepositorio
    {
        bool Salvar(Endereco registro);
        bool Atualizar(Endereco registro);
        bool Excluir(int id);
        Endereco Obter(int id);
        List<Endereco> Listar(int id, string cep);
        bool Existe(int id);
        bool Existe(Endereco registro);
        IPagedList<Endereco> ObterTodas(int? pagina);
    }
}
