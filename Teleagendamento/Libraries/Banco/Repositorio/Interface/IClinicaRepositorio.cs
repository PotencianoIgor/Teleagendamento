using System.Collections.Generic;
using System.Threading.Tasks;
using Teleagendamento.Models;
using Teleagendamento.Models.Enum;
using X.PagedList;

namespace Teleagendamento.Libraries.Banco.Repositorio.Interface
{
    public interface IClinicaRepositorio
    {
        bool Salvar(Clinica registro);
        bool Atualizar(Clinica registro);
        bool Excluir(int id);
        Clinica Obter(int id);
        List<Clinica> Listar(int id, string nome, string cnpj, TipoStatus status);
        bool Existe(int id, string nome, TipoStatus status);
        bool Existe(Clinica registro);
        IPagedList<Clinica> ObterTodas(int? pagina);
    }
}
