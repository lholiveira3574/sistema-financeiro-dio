using System.Collections.Generic;
using sistema_financeiro_dio.Entidades;
using sistema_financeiro_dio.Enums;
using sistema_financeiro_dio.Repositorios;

namespace sistema_financeiro_dio.Controllers
{
    public class ContaController
    {
        ContaRepositorio repositorio = new ContaRepositorio();
        public void Depositar(int idConta, double valorDeposito)
        {
            repositorio.Depositar(idConta, valorDeposito);
        }

        public void InserirConta(int id, TipoConta tipoConta, double saldo, double credito, string nome)
        {
            Conta novaConta = new Conta(id, tipoConta, saldo, credito, nome);     
            repositorio.InserirConta(novaConta);
        }

        public List<Conta> ListarContas()
        {
            return repositorio.ListarContas();
        }

        public bool Sacar(int idConta, double valorSaque)
        {
           return repositorio.Sacar(idConta, valorSaque);

        }

        public bool Transferir(int idContaOrigem, double valorTransferencia, int idContaDestino)
        {
            return repositorio.Transferir(idContaOrigem, valorTransferencia, idContaDestino);
        }

        public Conta BuscaPorId(int id)
        {
            return repositorio.BuscaPorId(id);
        }

        public int ValorId()
		{
			return repositorio.ValorId();
		}
    }
}