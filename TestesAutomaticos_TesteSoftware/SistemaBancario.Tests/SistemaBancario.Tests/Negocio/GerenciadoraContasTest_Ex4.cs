using SistemaBancario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

/**
* Classe de teste criada para garantir o funcionamento das principais operações
* sobre contas, realizadas pela classe {@link GerenciadoraContas}.
*
*@author Gustavo Farias
* @date 21/01/2035 
*/

namespace SistemaBancario.Tests.Negocio
{
    public class GerenciadoraContasTest_Ex4 {

        private GerenciadoraContas gerContas;

        /**
         * Teste b�sico da transferência de um valor da conta de um cliente para outro,
         * estando ambos os clientes ativos e havendo saldo suficiente para tal transfer�ncia
         * ocorrer com sucesso.
         * 
         * @author Gustavo Farias
         * @date 21/01/2035 */

        [Fact]
        public void testTransfereValor()
        {
            /* ========== Montagem do cen�rio ========== */

            // criando alguns clientes
            ContaCorrente conta01 = new ContaCorrente(1, 200, true);
            ContaCorrente conta02 = new ContaCorrente(2, 0, true);

            // inserindo os clientes criados na lista de clientes do banco
            List<ContaCorrente> contasDoBanco = new List<ContaCorrente>();
            contasDoBanco.Add(conta01);
            contasDoBanco.Add(conta02);

            gerContas = new GerenciadoraContas(contasDoBanco);

            /* ========== Execução ========== */
            bool sucesso = gerContas.TransfereValor(1, 100, 2);

            /* ========== Verificações ========== */
            Assert.True(sucesso);
            Assert.Equal(100.0, conta02.Saldo);
        }
    }
// Documentação e coment�rios
}
