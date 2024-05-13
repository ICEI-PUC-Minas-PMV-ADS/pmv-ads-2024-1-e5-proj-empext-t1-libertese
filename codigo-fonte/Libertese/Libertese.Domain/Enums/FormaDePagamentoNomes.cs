using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libertese.Domain.Enums
{
    public static class FormaDePagamentoNomes
    {
        public static readonly string Boleto = "Boleto";
        public static readonly string Cheque = "Cheque";
        public static readonly string CreditoPrazo = "Credito à prazo";
        public static readonly string CreditoVista = "Credito à vista";
        public static readonly string Debito = "Débito";
        public static readonly string Dinheiro = "Impostos";
        public static readonly string Pix = "Pix";
        public static readonly string Transferencia = "Transferência";
    }
}
