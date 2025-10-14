using System;

namespace SistemaBancario
{
    /// <summary>
    /// Classe Cliente que representa um cliente real do banco.
    /// </summary>
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public int IdContaCorrente { get; set; }

        public Cliente(int id, string nome, int idade, string email, int idContaCorrente, bool ativo)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Email = email;
            IdContaCorrente = idContaCorrente;
            Ativo = ativo;
        }

        /// <summary>
        /// Retorna a representação textual de um cliente.
        /// </summary>
        /// <returns>Representação textual de um cliente</returns>
        public override string ToString()
        {
            return "=========================" +
                   "\nId: " + Id +
                   "\nNome: " + Nome +
                   "\nEmail: " + Email +
                   "\nIdade: " + Idade +
                   "\nStatus: " + (Ativo ? "Ativo" : "Inativo") +
                   "\n=========================";
        }
    }
}
