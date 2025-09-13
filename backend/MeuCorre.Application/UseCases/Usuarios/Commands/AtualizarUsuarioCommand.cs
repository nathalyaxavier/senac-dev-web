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
    }

    internal class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand>
    {
        public Task<Unit> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            // Implementar a lógica de atualização do usuário aqui
            throw new NotImplementedException();
        }
    
      public async Task<(string, bool)>Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await UsuarioRepository.ObterUsuarioPorEmail(request.Email);
            if (usuario == null)
            {
                return ("Usuário não encontrado.", false);
            }

            // Atualiza apenas os campos permitidos
            usuario.AtualizarDados(
                nome: request.Nome,
                dataNascimento: request.DataNascimento
            );

            await UsuarioRepository.AtualizarUsuarioAsync(usuario);
            return ("Usuário atualizado com sucesso.", true);
        }

    }
