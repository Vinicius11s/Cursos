using System;
using System.Collections.Generic;
using Xunit;
using SistemaBancario;

namespace SistemaBancario.Tests.Negocio
{
    /// <summary>
    /// Classe de teste criada para garantir o funcionamento das principais operações
    /// sobre clientes, realizadas pela classe GerenciadoraClientes.
    /// 
    /// @author Gustavo Farias
    /// @date 21/01/2035 
    /// </summary>
    public class GerenciadoraClientesTest_Ex10 : IDisposable
    {
        private GerenciadoraClientes gerClientes;
        private int idCLiente01 = 1;
        private int idCLiente02 = 2;
        
        public GerenciadoraClientesTest_Ex10()
        {
            // ========== Montagem do cenário ==========
            
            // criando alguns clientes
            Cliente cliente01 = new Cliente(idCLiente01, "Gustavo Farias", 31, "gugafarias@gmail.com", 1, true);
            Cliente cliente02 = new Cliente(idCLiente02, "Felipe Augusto", 34, "felipeaugusto@gmail.com", 1, true);
            
            // inserindo os clientes criados na lista de clientes do banco
            List<Cliente> clientesDoBanco = new List<Cliente>();
            clientesDoBanco.Add(cliente01);
            clientesDoBanco.Add(cliente02);
            
            gerClientes = new GerenciadoraClientes(clientesDoBanco);
        }

        public void Dispose()
        {
            gerClientes.Limpa();
        }
        
        /// <summary>
        /// Teste básico da pesquisa de um cliente a partir do seu ID.
        /// 
        /// @author Gustavo Farias
        /// @date 21/01/2035
        /// </summary>
        [Fact]
        public void TestPesquisaCliente()
        {
            // ========== Execução ==========
            Cliente cliente = gerClientes.PesquisaCliente(idCLiente01);
            
            // ========== Verificações ==========
            Assert.Equal(idCLiente01, cliente.Id);
        }
        
        /// <summary>
        /// Teste básico da pesquisa por um cliente que não existe.
        /// 
        /// @author Gustavo Farias
        /// @date 21/01/2035
        /// </summary>
        [Fact]
        public void TestPesquisaClienteInexistente()
        {
            // ========== Execução ==========
            Cliente cliente = gerClientes.PesquisaCliente(1001);// pesquisando cliente que nao existe (= null)
            
            // ========== Verificações ==========
            Assert.Null(cliente);
        }
        
        /// <summary>
        /// Teste básico da remoção de um cliente a partir do seu ID.
        /// 
        /// @author Gustavo Farias
        /// @date 21/01/2035
        /// </summary>
        [Fact]
        public void TestRemoveCliente()
        {
            // ========== Execução ==========
            bool clienteRemovido = gerClientes.RemoveCliente(idCLiente02);
            
            // ========== Verificações ==========
            Assert.True(clienteRemovido);
            Assert.Equal(1, gerClientes.GetClientesDoBanco().Count);
            Assert.Null(gerClientes.PesquisaCliente(idCLiente02));
        }
        
        /// <summary>
        /// Teste da tentativa de remoção de um cliente inexistente.
        /// 
        /// @author Gustavo Farias
        /// @date 21/01/2035
        /// </summary>
        [Fact]
        public void TestRemoveClienteInexistente()
        {
            // ========== Execução ==========
            bool clienteRemovido = gerClientes.RemoveCliente(1001);
            
            // ========== Verificações ==========
            Assert.False(clienteRemovido);
            Assert.Equal(2, gerClientes.GetClientesDoBanco().Count);
        }
        
        /// <summary>
        /// Validação da idade de um cliente quando a mesma está no intervalo permitido.
        /// 
        /// @author Gustavo Farias
        /// @date 21/01/2035
        /// </summary>
        [Fact]
        public void TestClienteIdadeAceitavel()
        {
            // ========== Montagem do Cenário ==========		
            Cliente cliente = new Cliente(1, "Gustavo", 25, "guga@gmail.com", 1, true);
            
            // ========== Execução ==========
            bool idadeValida = gerClientes.ValidaIdade(cliente.Idade);
            
            // ========== Verificações ==========
            Assert.True(idadeValida);
        }
        
        /// <summary>
        /// Validação da idade de um cliente quando a mesma está no intervalo permitido.
        /// 
        /// @author Gustavo Farias
        /// @date 21/01/2035
        /// </summary>
        [Fact]
        public void TestClienteIdadeAceitavel_02()
        {
            // ========== Montagem do Cenário ==========		
            Cliente cliente = new Cliente(1, "Gustavo", 18, "guga@gmail.com", 1, true);
            
            // ========== Execução ==========
            bool idadeValida = gerClientes.ValidaIdade(cliente.Idade);
            
            // ========== Verificações ==========
            Assert.True(idadeValida);
        }
        
        /// <summary>
        /// Validação da idade de um cliente quando a mesma está no intervalo permitido.
        /// 
        /// @author Gustavo Farias
        /// @date 21/01/2035
        /// </summary>
        [Fact]
        public void TestClienteIdadeAceitavel_03()
        {
            // ========== Montagem do Cenário ==========		
            Cliente cliente = new Cliente(1, "Gustavo", 65, "guga@gmail.com", 1, true);
            
            // ========== Execução ==========
            bool idadeValida = gerClientes.ValidaIdade(cliente.Idade);
            
            // ========== Verificações ==========
            Assert.True(idadeValida);
        }
        
        /// <summary>
        /// Validação da idade de um cliente quando a mesma está abaixo intervalo permitido.
        /// 
        /// @author Gustavo Farias
        /// @date 21/01/2035
        /// </summary>
        [Fact]
        public void TestClienteIdadeAceitavel_04()
        {
            // ========== Montagem do Cenário ==========		
            Cliente cliente = new Cliente(1, "Gustavo", 17, "guga@gmail.com", 1, true);

            // ========== Execução ==========
            var exception = Assert.Throws<IdadeNaoPermitidaException>(() => 
                gerClientes.ValidaIdade(cliente.Idade));
            
            // ========== Verificações ==========
            Assert.Equal(IdadeNaoPermitidaException.MSG_IDADE_INVALIDA, exception.Message);
        }
        
        /// <summary>
        /// Validação da idade de um cliente quando a mesma está acima intervalo permitido.
        /// 
        /// @author Gustavo Farias
        /// @date 21/01/2035
        /// </summary>
        [Fact]
        public void TestClienteIdadeAceitavel_05()
        {
            // ========== Montagem do Cenário ==========		
            Cliente cliente = new Cliente(1, "Gustavo", 66, "guga@gmail.com", 1, true);
            
            // ========== Execução ==========
            var exception = Assert.Throws<IdadeNaoPermitidaException>(() => 
                gerClientes.ValidaIdade(cliente.Idade));
            
            // ========== Verificações ==========
            Assert.Equal(IdadeNaoPermitidaException.MSG_IDADE_INVALIDA, exception.Message);
        }
    }
}
