using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Fiap.MasterChefReceitas.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Fiap.MasterChefReceitas.Api.Controllers
{

    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpGet("{usuario}/{password}")]
        public async Task<IActionResult> Get(
                    string usuario,
                    string password,
                    [FromServices]UserManager<ApplicationUser> userManager,
                    [FromServices]SignInManager<ApplicationUser> signInManager,
                    [FromServices]SigningConfigurations signingConfigurations,
                    [FromServices]TokenConfigurations tokenConfigurations)
        {

            bool credenciaisValidas = false;
            var user = await userManager.FindByNameAsync(usuario);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(
                    usuario, password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                    credenciaisValidas = true;
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);


                return Ok(new
                {
                    accessToken = token
                });
            }
            else
                return BadRequest("Falha ao efetuar login");
        }
    }
}