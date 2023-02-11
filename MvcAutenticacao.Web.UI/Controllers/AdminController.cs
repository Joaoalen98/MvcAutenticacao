using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcAutenticacao.BLL;
using MvcAutenticacao.Models;

namespace MvcAutenticacao.Web.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUsuarioDados bll;

        public AdminController()
        {
            bll = new UsuarioBLL();
        }

        public IActionResult Usuarios()
        {
            var usuarios = bll.GetUsuarios();
            return View(usuarios);
        }

        public IActionResult Detalhes(string id)
        {
            var usuario = bll.ObterPorId(id);
            return View(usuario);
        }

        public IActionResult DeletarUsuario(string id)
        {
            var usuario = bll.ObterPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult DeletarUsuario(string id, IFormCollection form)
        {
            try
            {
                bll.Deletar(id);
                return RedirectToAction("Usuarios");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
