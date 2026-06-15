using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

/**
 * Classe de teste criada para garantir o funcionamento das principais opera��es
 * sobre clientes, realizadas pela classe {@link GerenciadoraClientes}.
 * 
 * @author Gustavo Farias
 * @date 21/01/2035 
 */

namespace SistemaBancario.Tests.Negocio
{
    public class GerenciadoraClientesTest_Ex5
    {
        private GerenciadoraClientes gerClientes;

        /**
         * Teste b�sico da pesquisa de um cliente a partir do seu ID.
         * 
         * @author Gustavo Farias
         * @date 21/01/2035
         */

        [Fact]
        public void testPesquisaCliente()
        {
            /* ========== Montagem do cen�rio ========== */

            // criando alguns clientes
            int idCLiente01 = 1;
            int idCLiente02 = 2;
            Cliente cliente01 = new Cliente(idCLiente01, "Gustavo Farias", 31, "gugafarias@gmail.com", 1, true);
            Cliente cliente02 = new Cliente(idCLiente02, "Felipe Augusto", 34, "felipeaugusto@gmail.com", 1, true);

            // inserindo os clientes criados na lista de clientes do banco
            List<Cliente> clientesDoBanco = new List<Cliente>();
            clientesDoBanco.Add(cliente01);
            clientesDoBanco.Add(cliente02);

            gerClientes = new GerenciadoraClientes(clientesDoBanco);

            /* ========== Execução ========== */
            Cliente cliente = gerClientes.PesquisaCliente(idCLiente01);

            /* ========== Verificações ========== */
            Assert.Equal(cliente.Id, idCLiente01);

        }

        /**
         * Teste b�sico da remoção de um cliente a partir do seu ID.
         * 
         * @author Gustavo Farias
         * @date 21/01/2035
         */
        [Fact]
        public void TestRemoveCliente()
        {
            /* ========== Montagem do cen�rio ========== */

            // criando alguns clientes
            int idCLiente01 = 1;
            int idCLiente02 = 2;
            Cliente cliente01 = new Cliente(idCLiente01, "Gustavo Farias", 31, "gugafarias@gmail.com", 1, true);
            Cliente cliente02 = new Cliente(idCLiente02, "Felipe Augusto", 34, "felipeaugusto@gmail.com", 1, true);

            // inserindo os clientes criados na lista de clientes do banco
            List<Cliente> clientesDoBanco = new List<Cliente>();
            clientesDoBanco.Add(cliente01);
            clientesDoBanco.Add(cliente02);

            gerClientes = new GerenciadoraClientes(clientesDoBanco);

            /* ========== Execução ========== */
            bool clienteRemovido = gerClientes.RemoveCliente(idCLiente02);

            /* ========== Verificações == ======== */
            Assert.True(clienteRemovido);
            Assert.Equal(1, gerClientes.GetClientesDoBanco().Count);
            Assert.Null(gerClientes.PesquisaCliente(idCLiente02));


        }
    }
}
