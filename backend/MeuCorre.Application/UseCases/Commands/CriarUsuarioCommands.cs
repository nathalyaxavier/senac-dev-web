using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Commands
{
    /// <summary>
    /// <Comando para criar um novo usuário>
    /// aqui você pode adicionar propriedades necessárias para criar o usuário, como Nome, Email, Senha, etc.
    /// </summary>
    public class CriarUsuarioCommands : IRequest<string>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; } 
    }
}
