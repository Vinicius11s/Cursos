using System;

namespace SistemaBancario
{
    /// <summary>
    /// Classe ContaCorrente que representa uma conta corrente real
    /// e que poderá ser associada a um cliente.
    /// </summary>
    public class ContaCorrente
    {
        public int Id { get; set; }
        public double Saldo { get; set; }
        public bool Ativa { get; set; }

        public ContaCorrente(int id, double saldo, bool ativa)
        {
            Id = id;
            Saldo = saldo;
            Ativa = ativa;
        }

        /// <summary>
        /// Retorna a representação textual de uma conta corrente.
        /// </summary>
        /// <returns>Representação textual da conta corrente</returns>
        public override string ToString()
        {
            return "=========================" +
                   "\nId: " + Id +
                   "\nSaldo: " + Saldo +
                   "\nStatus: " + (Ativa ? "Ativa" : "Inativa") +
                   "\n=========================";
        }
    }
}
