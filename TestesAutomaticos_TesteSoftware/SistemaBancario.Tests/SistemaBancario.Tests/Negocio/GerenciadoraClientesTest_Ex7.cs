using SistemaBancario;
using System;
using System.Collections.Generic;
using Xunit;

namespace SistemaBancario.Tests.Negocio
{
    public class GerenciadoraClientesTest_Ex7 : IDisposable
    {
        private GerenciadoraClientes gerClientes;
        private int idCliente01 = 1;
        private int idCliente02 = 2;

        // 👉 Equivalente ao [SetUp] do NUnit (SetUp = preparação)
        // construtor sempre é executado primeiro que os testes
        public GerenciadoraClientesTest_Ex7()
        {
            // ========== Montagem do cenário ==========
            Cliente cliente01 = new Cliente(idCliente01, "Gustavo Farias", 31, "gugafarias@gmail.com", 1, true);
            Cliente cliente02 = new Cliente(idCliente02, "Felipe Augusto", 34, "felipeaugusto@gmail.com", 1, true);

            // inserindo os clientes criados na lista de clientes do banco
            List<Cliente> clientesDoBanco = new List<Cliente> { cliente01, cliente02 };

            gerClientes = new GerenciadoraClientes(clientesDoBanco);
        }

        // 👉 Em xUnit [TearDown]; usa IDisposable
        // vai ser executado depois de cada método de teste.
        public void Dispose()
        {
            gerClientes.Limpa();
        }
        [Fact]
        public void TestPesquisaCliente()
        {
            // ========== Execução ==========
            Cliente cliente = gerClientes.PesquisaCliente(idCliente01);

            // ========== Verificações ==========
            Assert.Equal(idCliente01, cliente.Id);
        }
        [Fact]
        public void TestRemoveCliente()
        {
            // ========== Execução ==========
            bool clienteRemovido = gerClientes.RemoveCliente(idCliente02);

            // ========== Verificações ==========
            Assert.True(clienteRemovido);
            Assert.Equal(1, gerClientes.GetClientesDoBanco().Count);
            Assert.Null(gerClientes.PesquisaCliente(idCliente02));
        }
    }
}
