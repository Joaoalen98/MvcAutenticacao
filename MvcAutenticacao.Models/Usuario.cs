namespace MvcAutenticacao.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public virtual UserRole UserRole { get; set; }
        public int UserRoleId { get; set; }
    }
}
