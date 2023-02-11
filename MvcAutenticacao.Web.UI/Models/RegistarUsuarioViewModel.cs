using System.ComponentModel.DataAnnotations;

namespace MvcAutenticacao.Web.UI.Models
{
    public class RegistarUsuarioViewModel
    {
        [Required(ErrorMessage = "É necessário informar um nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário informar um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário informar uma senha")]
        public string Senha { get; set; }
    }
}
