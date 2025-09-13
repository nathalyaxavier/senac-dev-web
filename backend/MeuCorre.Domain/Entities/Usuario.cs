using System.Text.RegularExpressions;

namespace MeuCorre.Domain.Entities
{
    public class Usuario : Entidade
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }

        // Propriedade de navegação para a entidade Categoria pois
        // o usuário pode ter várias categorias
        public virtual ICollection<Categoria> Categorias { get; set; }


        //Construtor para criar um novo usuário.
        //Construtor é a primeira coisa que é executada quando uma classe é instanciada.
        public Usuario(string nome, string email, string senha, DateTime dataNascimento, bool ativo)
        {

            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Ativo = ativo;
        }

        //Regra negocio: Permite apenas usários maiores de 13 anos.
        private DateTime ValidarIdadeMinima(DateTime nascimento)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - nascimento.Year;

            if (nascimento.Date > hoje.AddYears(-idade))
                idade--;

            if (idade < 13)
            {
                //interrompe o processo devolvendo o erro.
                throw new Exception("Usuário deve ter no minimo 13 anos.");
            }

            return nascimento;

        }
       
        public string ValidarSenha(string senha)
        {
            //Regra de negocio: pelo menos uma letra e um número.
            
            if (!Regex.IsMatch(senha, "[a-z]"))
            {
                throw new Exception("A senha deve contar pelo menos uma letra minuscula");
            }
            if (!Regex.IsMatch(senha, "[A-Z]"))
            {
                throw new Exception("A senha deve contar pelo menos uma letra maiuscula");
            }
            if (!Regex.IsMatch(senha, "[0-9]"))
            {
                throw new Exception("A senha deve contar pelo menos um números");
            }

            return senha;
        }

        public string ValidarSenha(string senha)
        {
            if (senha.Length < 6)
            {
                //Todo Fazer um tratamento de erro melhor
            }
            return senha;
        }

        public void AtivarUsuario()
        {
            Ativo = true;
            AtualizarDataMoficacao();
        }

        public void InativarUsuario()
        {
            Ativo = false;
            AtualizarDataMoficacao();
        }
    }
}
