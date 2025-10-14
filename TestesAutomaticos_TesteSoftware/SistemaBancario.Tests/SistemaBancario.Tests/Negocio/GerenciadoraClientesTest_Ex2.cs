using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaBancario.Tests.Negocio
{
    public class GerenciadoraClientesTest_Ex2
    {
        [Fact]
        public void testPesquisaCliente()
        {
            // criando alguns clientes
            Cliente cliente01 = new Cliente(1, "Gustavo Farias", 31, "gugafarias@gmail.com", 1, true);
            Cliente cliente02 = new Cliente(2, "Felipe Augusto", 34, "felipeaugusto@gmail.com", 2, true);

            // inserindo os clientes criados na lista de clientes do banco
            List<Cliente> clientesDoBanco = new List<Cliente>();
            clientesDoBanco.Add(cliente01);
            clientesDoBanco.Add(cliente02);

            GerenciadoraClientes gerClientes = new GerenciadoraClientes(clientesDoBanco);

            Cliente cliente = gerClientes.PesquisaCliente(1);

            Assert.Equal(1, cliente.Id);
            Assert.Equal("gugafarias@gmail.com", cliente.Email);
        }


        [Fact]
        public void testRemoveCliente()
        {
            //criando meu cenário, minha lista
            Cliente cliente01 = new Cliente(1, "Gustavo Farias", 31, "gugafarias@gmail.com", 1, true);
            Cliente cliente02 = new Cliente(2, "Felipe Augusto", 34, "felipeaugusto@gmail.com", 2, true);

            //adicionando clientes na lista
            List<Cliente> clientesDoBanco = new List<Cliente>();
            clientesDoBanco.Add(cliente01);
            clientesDoBanco.Add(cliente02);

            GerenciadoraClientes gerClientes = new GerenciadoraClientes(clientesDoBanco);

            bool clienteRemovido = gerClientes.RemoveCliente(2);

            Assert.True(clienteRemovido);
            Assert.Equal(1, gerClientes.GetClientesDoBanco().Count);//verifique o tamanhoo da linha se foi de 2 para 1 
            Assert.Null(gerClientes.PesquisaCliente(2));//verifique se a resposta da pesquisa pelo cliente 2 é null , já que foi removido
        }
    }
}
