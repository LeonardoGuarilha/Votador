using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Votador.Compartilhado;
using Votador.Dominio.Entidades;

namespace Votador.Dominio.Servico
{
    public static class ServicoToken
    {
        public static string GerarToken(Funcionario funcionario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuracoes.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(ClaimTypes.Name, funcionario.Email),  
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = 
                    new SigningCredentials(
                        new SymmetricSecurityKey(key), 
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}