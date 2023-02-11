namespace MvcAutenticacao.BLL
{
    public static class HashHelper
    {
        public static string HashSenha(string senha)
        {
            var salts = BCrypt.Net.BCrypt.GenerateSalt(8);
            var hash = BCrypt.Net.BCrypt.HashPassword(senha);
            return hash;
        }

        public static bool ComparaSenha(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}
