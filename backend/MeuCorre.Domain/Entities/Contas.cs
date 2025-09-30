using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Conta : Entidade
{
    // Propriedades obrigatórias
    public string Nome { get; set; }
    public string Tipo { get; set; } 
    public decimal Saldo { get; set; }
    public Guid UsuarioId { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCriacao { get; set; }

    // Propriedades opcionais
    public decimal? Limite { get; set; }
    public int? DiaFechamento { get; set; }
    public int? DiaVencimento { get; set; }
    public string Cor { get; set; }
    public string Icone { get; set; }
    public DateTime? DataAtualizacao { get; set; }

    // Navigation property
    public Usuario Usuario { get; set; }

    // Métodos de domínio
    public bool EhCartaoCredito()
    {
        return Tipo?.Equals("CartaoCredito", StringComparison.OrdinalIgnoreCase) == true;
    }

    public bool EhCarteira()
    {
        return Tipo?.Equals("Carteira", StringComparison.OrdinalIgnoreCase) == true;
    }

    public decimal CalcularLimiteDisponivel()
    {
        if (!EhCartaoCredito() || Limite == null)
            return 0;

        return Limite.Value - Saldo;
    }

    public bool PodeFazerDebito(decimal valor)
    {
        if (EhCartaoCredito())
        {
            return CalcularLimiteDisponivel() >= valor;
        }

        return Saldo >= valor;
    }
}

