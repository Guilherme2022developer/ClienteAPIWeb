using MinhaAPIWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAPIWeb.Repositorio
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> Get();

        Task<Cliente> Get(int Id);
        Task<Cliente> Create(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(int id);

    }
}
