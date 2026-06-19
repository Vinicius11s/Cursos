using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario
{
    /// <summary>
    /// Classe de negócio para realizar operações sobre as contas do banco.
    /// </summary>
    public class GerenciadoraContas
    {
        private List<ContaCorrente> contasDoBanco;

        public GerenciadoraContas(List<ContaCorrente> contasDoBanco)
        {
            this.contasDoBanco = contasDoBanco;
        }

        /// <summary>
        /// Retorna uma lista com todas as contas do banco.
        /// </summary>
        /// <returns>Lista com todas as contas do banco</returns>
        public List<ContaCorrente> GetContasDoBanco()
        {
            return contasDoBanco;
        }

        /// <summary>
        /// Pesquisa por uma conta a partir do seu ID.
        /// </summary>
        /// <param name="idConta">ID da conta a ser pesquisada</param>
        /// <returns>A conta pesquisada ou null, caso não seja encontrada</returns>
        public ContaCorrente PesquisaConta(int idConta)
        {
            return contasDoBanco.FirstOrDefault(conta => conta.Id == idConta);
        }

        /// <summary>
        /// Adiciona uma nova conta à lista de contas do banco.
        /// </summary>
        /// <param name="novaConta">Nova conta a ser adicionada</param>
        public void AdicionaConta(ContaCorrente novaConta)
        {
            contasDoBanco.Add(novaConta);
        }

        /// <summary>
        /// Remove conta da lista de contas do banco.
        /// </summary>
        /// <param name="idConta">ID da conta a ser removida</param>
        /// <returns>True se a conta foi removida. False, caso contrário.</returns>
        public bool RemoveConta(int idConta)
        {
            var conta = contasDoBanco.FirstOrDefault(c => c.Id == idConta);
            if (conta != null)
            {
                contasDoBanco.Remove(conta);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Informa se uma determinada conta está ativa ou não.
        /// </summary>
        /// <param name="idConta">ID da conta cujo status será verificado</param>
        /// <returns>True se a conta está ativa. False, caso contrário.</returns>
        public bool ContaAtiva(int idConta)
        {
            var conta = contasDoBanco.FirstOrDefault(c => c.Id == idConta);
            return conta?.Ativa ?? false;
        }

        /// <summary>
        /// Transfere um determinado valor de uma conta Origem para uma conta Destino.
        /// Caso não haja saldo suficiente, o valor não será transferido.
        /// </summary>
        /// <param name="idContaOrigem">Conta que terá o valor deduzido</param>
        /// <param name="valor">Valor a ser transferido</param>
        /// <param name="idContaDestino">Conta que terá o valor acrescido</param>
        /// <returns>True, se a transferência foi realizada com sucesso.</returns>
        public bool TransfereValor(int idContaOrigem, double valor, int idContaDestino)
        {
            bool sucesso = false;

            ContaCorrente contaOrigem = PesquisaConta(idContaOrigem);
            ContaCorrente contaDestino = PesquisaConta(idContaDestino);

            if (contaOrigem != null && contaDestino != null)
            {
                // Comentado para manter a mesma lógica do código original
                // if (contaOrigem.Saldo >= valor)
                // {
                contaDestino.Saldo += valor;
                contaOrigem.Saldo -= valor;
                sucesso = true;
                // }
            }

            return sucesso;
        }
    }
}
