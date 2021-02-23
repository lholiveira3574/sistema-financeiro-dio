using System;
using System.Collections.Generic;
using sistema_financeiro_dio.Classes;
using sistema_financeiro_dio.Controllers;
using sistema_financeiro_dio.Enums;

namespace sistema_financeiro_dio
{
    class Program
    {
		static ContaController contaController = new ContaController();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}
			
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
            
        }

		private static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("DIO Bank a seu dispor!!!");
                Console.WriteLine("Informe a opção desejada:");

                Console.WriteLine("1- Listar contas");
                Console.WriteLine("2- Inserir nova conta");
                Console.WriteLine("3- Transferir");
                Console.WriteLine("4- Sacar");
                Console.WriteLine("5- Depositar");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
			int idConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

			contaController.Depositar(idConta, valorDeposito);

			Conta conta = contaController.BuscaPorId(idConta);

			Console.WriteLine(conta);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
			int idConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

			bool saqueRealizado = contaController.Sacar(idConta, valorSaque);

			if (saqueRealizado) 
			{
				Conta conta = contaController.BuscaPorId(idConta);

				Console.WriteLine(conta);
			}
			else
			{
				Console.WriteLine("Não foi possível realizar a operção. Saldo insuficiente!");	
			}
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
			int idContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int idContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

			bool transferenciaRealizada = contaController.Transferir(idContaOrigem, 
																	 valorTransferencia, 
																	 idContaDestino);

			if (transferenciaRealizada)
			{
				Conta conta = contaController.BuscaPorId(idContaOrigem);

				Console.WriteLine(conta);
			}
			else
			{
				Console.WriteLine("Não foi possível realizar a operção. Saldo insuficiente!");	
			}

        }

        private static void InserirConta()
        {
			Console.WriteLine("Inserir nova conta");

			int id = contaController.ValorId();

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int tipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string Nome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double Saldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double Credito = double.Parse(Console.ReadLine());

            contaController.InserirConta(id, (TipoConta)tipoConta, Saldo, Credito, Nome);
        }

        private static void ListarContas()
        {
			List<Conta> contasCadastradas = contaController.ListarContas();

			if (contasCadastradas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			foreach(Conta conta in contasCadastradas)
			{
				Console.WriteLine(conta);
			}
        }

    }
}
