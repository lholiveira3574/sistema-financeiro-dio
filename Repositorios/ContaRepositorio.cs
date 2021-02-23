using System.Collections.Generic;
using sistema_financeiro_dio.Classes;

namespace sistema_financeiro_dio.Repositorios
{
    public class ContaRepositorio
    {
        private List<Conta> listaContas = new List<Conta>(); 

        public void Depositar(int idConta, double valorDeposito)
        {
            listaContas[idConta].Depositar(valorDeposito);
        }

        public void InserirConta(Conta novaConta)
        {
            listaContas.Add(novaConta);    
        }

        public List<Conta> ListarContas()
        {
            return listaContas;
        }

        public bool Sacar(int idConta, double valorSaque)
        {
            return listaContas[idConta].Sacar(valorSaque);
        }

        public bool Transferir(int idContaOrigem, double valorTransferencia, int idContaDestino)
        {
            return listaContas[idContaOrigem].Transferir(valorTransferencia, listaContas[idContaDestino]);
        }  

        public Conta BuscaPorId(int id)
        {
            return listaContas[id];
        }

        public int ValorId()
		{
			return listaContas.Count;
		}
    }
}