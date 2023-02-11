using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcAutenticacao.BLL;
using MvcAutenticacao.Models;
using MvcAutenticacao.Web.UI.App_Code;
using MvcAutenticacao.Web.UI.Models;

namespace MvcAutenticacao.Web.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioDados bll;

        public UsuarioController()
        {
            bll = new UsuarioBLL();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = bll.ObterPorEmail(model.Email);

                    var senhaCorreta = HashHelper.ComparaSenha(model.Senha, usuario.Senha);
                    if (!senhaCorreta)
                    {
                        ModelState.AddModelError("", "Email ou senha incorreta");
                        return View(model);
                    }

                    var claimsPrincipal = AutenticacaoHelper.SignUsuario(usuario);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    Response.Redirect("/Usuario/Dados");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(model);
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(RegistarUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = new Usuario
                    {
                        Nome = model.Nome,
                        Email = model.Email,
                        Senha = model.Senha,
                    };

                    var registrar = bll.Criar(usuario);
                    Response.Redirect("/Usuario/Login");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(model);
        }


        [Authorize]
        public IActionResult Dados()
        {
            var id = User.FindFirst("Id")!.Value;

            var usuario = bll.ObterPorId(id);
            return View(usuario);
        }
    }
}
