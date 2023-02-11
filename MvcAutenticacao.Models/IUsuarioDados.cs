namespace MvcAutenticacao.Models
{
    public interface IUsuarioDados
    {
        Usuario Criar(Usuario model);
        Usuario ObterPorId(string id);
        Usuario ObterPorEmail(string email);
        IEnumerable<Usuario> GetUsuarios();
        Usuario Editar(Usuario model);
        Usuario Deletar(string id);
    }
}
