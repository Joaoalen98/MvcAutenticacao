using Microsoft.AspNetCore.Authentication.Cookies;
using MvcAutenticacao.Models;
using System.Security.Claims;

namespace MvcAutenticacao.Web.UI.App_Code
{
    public static class AutenticacaoHelper
    {
        public static ClaimsPrincipal SignUsuario(Usuario usuario)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.UserRole.Nome),
                new Claim("Id", usuario.Id),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            return principal;
        }
    }
}
