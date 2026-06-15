using System;
using System.Collections.Generic;
using Xunit;
using SistemaBancario;

namespace SistemaBancario.Tests.Negocio
{
    /// <summary>
    /// Classe de teste criada para garantir o funcionamento das principais operações
    /// sobre contas, realizadas pela classe GerenciadoraContas.
    /// 
    /// @author Gustavo Farias
    /// @date 21/01/2035 
    /// </summary>

    public class GerenciadoraContasTest_Ex6
    {
        private GerenciadoraContas gerContas;

        /// Teste básico da transferência de um valor da conta de um cliente para outro,
        /// estando ambos os clientes ativos e havendo saldo suficiente para tal transferência
        /// ocorrer com sucesso.
        /// 
        /// @author Gustavo Farias
        /// @date 21/01/2035
        [Fact]
        public void TestTransfereValor()
        {
            // ========== Montagem do cenário ==========
            
            // criando algumas contas
            int idConta01 = 1;
            int idConta02 = 2;
            ContaCorrente conta01 = new ContaCorrente(idConta01, 200, true);
            ContaCorrente conta02 = new ContaCorrente(idConta02, 0, true);
            
            // inserindo as contas criadas na lista de contas do banco
            List<ContaCorrente> contasDoBanco = new List<ContaCorrente>();
            contasDoBanco.Add(conta01);
            contasDoBanco.Add(conta02);
            
            gerContas = new GerenciadoraContas(contasDoBanco);

            // ========== Execução ==========
            bool sucesso = gerContas.TransfereValor(idConta01, 100, idConta02);
            
            // ========== Verificações ==========
            Assert.True(sucesso);
            Assert.Equal(100.0, conta02.Saldo);
            Assert.Equal(100.0, conta01.Saldo);
        }
        
        /// Teste básico da tentativa de transferência de um valor da conta de um cliente para outro
        /// quando não há saldo suficiente.
        /// 
        /// @author Gustavo Farias
        /// @date 21/01/2035
         
        [Fact]
        public void TestTransfereValor_SaldoInsuficiente()
        {
            // ========== Montagem do cenário ==========
            
            // criando algumas contas
            int idConta01 = 1;
            int idConta02 = 2;
            ContaCorrente conta01 = new ContaCorrente(idConta01, 100, true);
            ContaCorrente conta02 = new ContaCorrente(idConta02, 0, true);
            
            // inserindo as contas criadas na lista de contas do banco
            List<ContaCorrente> contasDoBanco = new List<ContaCorrente>();
            contasDoBanco.Add(conta01);
            contasDoBanco.Add(conta02);
            
            gerContas = new GerenciadoraContas(contasDoBanco);

            // ========== Execução ==========
            bool sucesso = gerContas.TransfereValor(idConta01, 200, idConta02);
            
            // ========== Verificações ==========
            Assert.True(sucesso);
            Assert.Equal(-100.00, conta01.Saldo);
            Assert.Equal(200, conta02.Saldo);
        }
    }
}
