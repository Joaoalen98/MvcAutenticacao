using Microsoft.EntityFrameworkCore;
using MvcAutenticacao.Models;

namespace MvcAutenticacao.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(DbHelper.Conexao);
        }
    }
}
