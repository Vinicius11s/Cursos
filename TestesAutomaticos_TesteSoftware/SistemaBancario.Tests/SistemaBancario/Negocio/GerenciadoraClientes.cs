using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario
{
    /// Classe de negócio para realizar operações sobre os clientes do banco.
    public class GerenciadoraClientes
    {
        private List<Cliente> clientesDoBanco;
        public GerenciadoraClientes(List<Cliente> clientesDoBanco)
        {
            this.clientesDoBanco = clientesDoBanco;
        }

        /// Retorna uma lista com todos os clientes do banco.
        public List<Cliente> GetClientesDoBanco()
        {
            return clientesDoBanco;
        }

        /// Pesquisa por um cliente a partir do seu ID.
        public Cliente PesquisaCliente(int idCliente)
        {
            return clientesDoBanco.FirstOrDefault(cliente => cliente.Id == idCliente);
        }

        /// Adiciona um novo cliente à lista de clientes do banco.
        public void AdicionaCliente(Cliente novoCliente)
        {
            clientesDoBanco.Add(novoCliente);
        }

        /// <summary>
        /// Remove cliente da lista de clientes do banco.
        /// </summary>
        /// <param name="idCliente">ID do cliente a ser removido</param>
        /// <returns>True se o cliente foi removido. False, caso contrário.</returns>
        public bool RemoveCliente(int idCliente)
        {
            var cliente = clientesDoBanco.FirstOrDefault(c => c.Id == idCliente);
            if (cliente != null)
            {
                clientesDoBanco.Remove(cliente);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Informa se um determinado cliente está ativo ou não.
        /// </summary>
        /// <param name="idCliente">ID do cliente cujo status será verificado</param>
        /// <returns>True se o cliente está ativo. False, caso contrário.</returns>
        public bool ClienteAtivo(int idCliente)
        {
            var cliente = clientesDoBanco.FirstOrDefault(c => c.Id == idCliente);
            return cliente?.Ativo ?? false;
        }

        /// <summary>
        /// Limpa a lista de clientes, ou seja, remove todos eles.
        /// </summary>
        public void Limpa()
        {
            clientesDoBanco.Clear();
        }

        /// <summary>
        /// Valida se a idade do cliente está dentro do intervalo permitido (18 - 65).
        /// </summary>
        /// <param name="idade">A idade do possível novo cliente</param>
        /// <returns>True se a idade é válida</returns>
        /// <exception cref="IdadeNaoPermitidaException">Lançada quando a idade não está no intervalo permitido</exception>
        public bool ValidaIdade(int idade)
        {
            if (idade < 18 || idade > 65)
                throw new IdadeNaoPermitidaException(IdadeNaoPermitidaException.MSG_IDADE_INVALIDA);

            return true;
        }
    }
}
