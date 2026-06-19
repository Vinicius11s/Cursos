using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SistemaBancario.Tests.Negocio
{
    public class GerenciadoraContasTest_Ex3
    {
        [Fact]
        public void TestTransfereValor()
        {
            /* ========== Montagem do cen�rio ========== */
            // criando algumas contas
            ContaCorrente conta01 = new ContaCorrente(1, 200, true);
            ContaCorrente conta02 = new ContaCorrente(2, 0, true);

            // inserindo as contas criadas na lista de contas do banco
            List<ContaCorrente> contasDoBanco = new List<ContaCorrente>();
            contasDoBanco.Add(conta01);
            contasDoBanco.Add(conta02);

            GerenciadoraContas gerContas = new GerenciadoraContas(contasDoBanco);

            /* ========== Execução ========== */
            gerContas.TransfereValor(1, 100, 2);

            /* ========== Verificações ========== */
            Assert.Equal(100.0, conta02.Saldo);
            Assert.Equal(100.0, conta01.Saldo);
        }
    }
}
