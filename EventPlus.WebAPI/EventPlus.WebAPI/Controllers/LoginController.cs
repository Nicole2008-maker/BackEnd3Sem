using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDto)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDto.Email!, loginDto.Senha!);

                if (usuarioBuscado == null)
                {
                    return Unauthorized(new { mensagem = "Email ou Senha inválidos." });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()!),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),
                };


                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-secreta-eventplus-webapi-dev-2026-!@#"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "eventplus.webapi",
                    audience: "eventplus.webapi",
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(2), // 2 horas de expiração é mais padrão
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception e)
            {
                // Em produção, não retornar o erro técnico diretamente (e.Message)
                return BadRequest(new { mensagem = "Erro interno", erro = e.Message });
            }
        }
    }
}
