using SistemaBancario;

class Program
{
    static GerenciadoraClientes gerClientes;
    static GerenciadoraContas gerContas;

    static void Main(string[] args)
    {
        InicializaSistemaBancario(); // criando algumas contas e clientes fictícios

        bool continua = true;

        while (continua)
        {
            PrintMenu();

            string input = Console.ReadLine();
            if (int.TryParse(input, out int opcao))
            {
                switch (opcao)
                {
                    // Consultar por um cliente
                    case 1:
                        Console.Write("Digite o ID do cliente: ");
                        if (int.TryParse(Console.ReadLine(), out int idCliente))
                        {
                            Cliente cliente = gerClientes.PesquisaCliente(idCliente);

                            if (cliente != null)
                                Console.WriteLine(cliente.ToString());
                            else
                                Console.WriteLine("Cliente não encontrado!");
                        }
                        else
                        {
                            Console.WriteLine("ID inválido!");
                        }

                        PulaLinha();
                        break;

                    // Consultar por uma conta corrente
                    case 2:
                        Console.Write("Digite o ID da conta: ");
                        if (int.TryParse(Console.ReadLine(), out int idConta))
                        {
                            ContaCorrente conta = gerContas.PesquisaConta(idConta);

                            if (conta != null)
                                Console.WriteLine(conta.ToString());
                            else
                                Console.WriteLine("Conta não encontrada!");
                        }
                        else
                        {
                            Console.WriteLine("ID inválido!");
                        }

                        PulaLinha();
                        break;

                    // Ativar um cliente
                    case 3:
                        Console.Write("Digite o ID do cliente: ");
                        if (int.TryParse(Console.ReadLine(), out int idCliente2))
                        {
                            Cliente cliente2 = gerClientes.PesquisaCliente(idCliente2);

                            if (cliente2 != null)
                            {
                                cliente2.Ativo = true;
                                Console.WriteLine("Cliente ativado com sucesso!");
                            }
                            else
                                Console.WriteLine("Cliente não encontrado!");
                        }
                        else
                        {
                            Console.WriteLine("ID inválido!");
                        }

                        PulaLinha();
                        break;

                    // Desativar um cliente
                    case 4:
                        Console.Write("Digite o ID do cliente: ");
                        if (int.TryParse(Console.ReadLine(), out int idCliente3))
                        {
                            Cliente cliente3 = gerClientes.PesquisaCliente(idCliente3);

                            if (cliente3 != null)
                            {
                                cliente3.Ativo = false;
                                Console.WriteLine("Cliente desativado com sucesso!");
                            }
                            else
                                Console.WriteLine("Cliente não encontrado!");
                        }
                        else
                        {
                            Console.WriteLine("ID inválido!");
                        }

                        PulaLinha();
                        break;

                    // Sair
                    case 5:
                        continua = false;
                        Console.WriteLine("################# Sistema encerrado #################");
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }
    }

    private static void PulaLinha()
    {
        Console.WriteLine("\n");
    }

    /// <summary>
    /// Imprime menu de opções do nosso sistema bancário
    /// </summary>
    private static void PrintMenu()
    {
        Console.WriteLine("O que você deseja fazer? \n");
        Console.WriteLine("1) Consultar por um cliente");
        Console.WriteLine("2) Consultar por uma conta corrente");
        Console.WriteLine("3) Ativar um cliente");
        Console.WriteLine("4) Desativar um cliente");
        Console.WriteLine("5) Sair");
        Console.WriteLine();
    }

    /// <summary>
    /// Método que cria e insere algumas contas e clientes no sistema do banco,
    /// apenas para realização de testes manuais através do método Main acima.
    /// </summary>
    private static void InicializaSistemaBancario()
    {
        // criando lista vazia de contas e clientes
        List<ContaCorrente> contasDoBanco = new List<ContaCorrente>();
        List<Cliente> clientesDoBanco = new List<Cliente>();

        // criando e inserindo duas contas na lista de contas correntes do banco
        ContaCorrente conta01 = new ContaCorrente(1, 0, true);
        ContaCorrente conta02 = new ContaCorrente(2, 0, true);
        contasDoBanco.Add(conta01);
        contasDoBanco.Add(conta02);

        // criando dois clientes e associando as contas criadas acima a eles
        Cliente cliente01 = new Cliente(1, "Gustavo Farias", 31, "gugafarias@gmail.com", conta01.Id, true);
        Cliente cliente02 = new Cliente(2, "Felipe Augusto", 34, "felipeaugusto@gmail.com", conta02.Id, true);
        // inserindo os clientes criados na lista de clientes do banco
        clientesDoBanco.Add(cliente01);
        clientesDoBanco.Add(cliente02);

        gerClientes = new GerenciadoraClientes(clientesDoBanco);
        gerContas = new GerenciadoraContas(contasDoBanco);
    }
}
