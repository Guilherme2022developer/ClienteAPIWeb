using Microsoft.EntityFrameworkCore;
using MinhaAPIWeb.Models;

namespace ClienteAPIWeb.Models
{
    public class ClienteContext : DbContext
    {
        public ClienteContext( DbContextOptions <ClienteContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Cliente> Clientes { get; set; }
        

        
    }
}
