using Microsoft.EntityFrameworkCore;
using MvcAutenticacao.Models;

namespace MvcAutenticacao.DAL
{
    public class UsuarioDAL : IUsuarioDados
    {
        private readonly AppDbContext db;

        public UsuarioDAL()
        {
            db = new AppDbContext();
        }

        public Usuario Criar(Usuario model)
        {
            var add = db.Usuarios.Add(model);
            db.SaveChanges();
            return add.Entity;
        }

        public Usuario Deletar(string id)
        {
            var usuario = ObterPorId(id);
            var del = db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return del.Entity;
        }

        public Usuario Editar(Usuario model)
        {
            model.Nome = model.Nome;
            model.UserRoleId = model.UserRoleId;
            model.Email = model.Email;
            model.Senha = model.Senha;

            var updt = db.Usuarios.Update(model);
            db.SaveChanges();
            return updt.Entity;
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            var usuarios = db.Usuarios
                .Include(x => x.UserRole)
                .ToList();

            return usuarios;
        }

        public Usuario ObterPorEmail(string email)
        {
            var usuario = db.Usuarios
                .Include(x => x.UserRole)
                .FirstOrDefault(x => x.Email == email);

            return usuario;
        }

        public Usuario ObterPorId(string id)
        {
            var usuario = db.Usuarios
                .Include(x => x.UserRole)
                .FirstOrDefault(x => x.Id == id);

            return usuario;
        }
    }
}
