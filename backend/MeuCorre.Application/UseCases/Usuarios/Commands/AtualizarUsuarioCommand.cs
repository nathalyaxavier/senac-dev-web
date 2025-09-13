using MediatR;
using MeuCorre.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Usuarios.Commands
{
    public class AtualizarUsuarioCommand : IRequest<(string, bool)>
    {

        [Required(ErrorMessage = "Nome é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        public required Guid Id { get; set; }
    }

    internal class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, (string, bool)>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AtualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Task<(string, bool)> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioExistente = await _usuarioRepository.ObterUsuarioPorId(request.id);
            if (usuario == null)
            {
                return ("Usuário não encontrado.", false);
            }
            // Atualiza os dados do usuário
            usuarioExistente.AtualizarUsuarioCommand(
                request.Nome,
                request.Email,
                request.DataNascimento,
                true
            );

            
        }
    }
}