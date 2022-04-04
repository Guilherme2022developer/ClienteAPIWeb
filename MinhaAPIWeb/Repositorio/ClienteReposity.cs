using ClienteAPIWeb.Models;
using Microsoft.EntityFrameworkCore;
using MinhaAPIWeb.Models;
using MinhaAPIWeb.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteAPIWeb.Repositorio
{
    public class ClienteReposity : IClienteRepository
    {
        public readonly ClienteContext _context;

        public ClienteReposity (ClienteContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task Delete(int id)
        {
            var clientetoDelete = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clientetoDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
