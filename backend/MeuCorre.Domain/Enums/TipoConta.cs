using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Domain.Enums
{
    public enum TipoConta
    {
        /// <summary>
        /// Conta do tipo carteira, geralmente usada para dinheiro físico ou saldo disponível para uso imediato.
        /// </summary>
        Carteira = 1,

        /// <summary>
        /// Conta bancária tradicional, como conta corrente ou poupança em instituições financeiras.
        /// </summary>
        ContaBancaria = 2,

        /// <summary>
        /// Conta de cartão de crédito, com limite e vencimento, usada para compras parceladas ou a prazo.
        /// </summary>
        CartaoCredito = 3
    }
}
