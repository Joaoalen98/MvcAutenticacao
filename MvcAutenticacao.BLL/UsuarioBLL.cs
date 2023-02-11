using MvcAutenticacao.DAL;
using MvcAutenticacao.Models;

namespace MvcAutenticacao.BLL
{
    public class UsuarioBLL : IUsuarioDados
    {
        private readonly IUsuarioDados dal;

        public UsuarioBLL()
        {
            dal = new UsuarioDAL();
        }

        public Usuario Criar(Usuario model)
        {
            var usuario = dal.ObterPorEmail(model.Email);

            if (usuario != null)
            {
                throw new ApplicationException("Email já cadastrado");
            }

            if (string.IsNullOrEmpty(model.Id))
            {
                model.Id = Guid.NewGuid().ToString();
            }

            var senhaHash = HashHelper.HashSenha(model.Senha);
            model.Senha = senhaHash;
            model.UserRoleId = (int)RolesEnum.UsuarioComum;

            var add = dal.Criar(model);
            return add;
        }

        public Usuario Deletar(string id)
        {
            var usuario = dal.ObterPorId(id);

            if (usuario == null)
            {
                throw new ApplicationException("Usuario não encontrado");
            }

            return dal.Deletar(id);
        }

        public Usuario Editar(Usuario model)
        {
            var senhaHash = HashHelper.HashSenha(model.Senha);
            model.Senha = senhaHash;

            return dal.Editar(model);
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return dal.GetUsuarios();
        }

        public Usuario ObterPorEmail(string email)
        {
            var usuario = dal.ObterPorEmail(email);

            if (usuario == null)
            {
                throw new ApplicationException("Usuario não encontrado");
            }

            return usuario;
        }

        public Usuario ObterPorId(string id)
        {
            return dal.ObterPorId(id);
        }
    }
}
