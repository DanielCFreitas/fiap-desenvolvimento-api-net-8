using Desafio.Api.Fiap.API.Repositories.Interfaces;
using Desafio.Api.Fiap.API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Desafio.Api.Fiap.API.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticacaoService(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> RecuperarTokenDeAcesso(string login, string senha)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorLoginESenha(login, senha);

            if (usuario == null)
                return string.Empty;

            var securityTokenDescriptor = RecuperarTokenDescriptor(login);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Retorna o security token descriptor, que descreve todas as propriedades que nosso
        /// token deve possuir quando o token for descriptografado
        /// </summary>
        /// <returns></returns>
        private SecurityTokenDescriptor RecuperarTokenDescriptor(string login)
        {
            var chaveCriptografada = RecuperarChaveDeCriptografia();

            return new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, login),
                ]),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chaveCriptografada),
                    SecurityAlgorithms.HmacSha256Signature)
            };
        }

        /// <summary>
        /// Recupera a chave de criptografia usada para gerar o token
        /// </summary>
        /// <returns>Array de bytes da chave de criptografia</returns>
        private byte[] RecuperarChaveDeCriptografia()
        {
            var chave = _configuration.GetValue<string>("SecretJWT")!;
            return Encoding.ASCII.GetBytes(chave);
        }
    }
}
