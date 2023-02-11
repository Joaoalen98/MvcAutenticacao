using System.ComponentModel.DataAnnotations;

namespace MvcAutenticacao.Web.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "É necessário enviar o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário enviar um senha")]
        public string Senha { get; set; }
    }
}
