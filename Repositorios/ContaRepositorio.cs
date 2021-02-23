using System.Collections.Generic;
using sistema_financeiro_dio.Entidades;
using sistema_financeiro_dio.Entidades.Exceptions;

namespace sistema_financeiro_dio.Repositorios
{
    public class ContaRepositorio
    {
        private List<Conta> listaContas = new List<Conta>(); 

        public void Depositar(int idConta, double valorDeposito)
        {
            ValidaSeExisteContasCadastradas(); 

            ValidaSeContaEstaCadastrada(idConta);

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
            ValidaSeExisteContasCadastradas(); 

            ValidaSeContaEstaCadastrada(idConta);

            return listaContas[idConta].Sacar(valorSaque);
        }

        public bool Transferir(int idContaOrigem, double valorTransferencia, int idContaDestino)
        {
            ValidaSeExisteContasCadastradas(); 

            ValidaSeContaEstaCadastrada(idContaOrigem);

            ValidaSeContaEstaCadastrada(idContaDestino);

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

        private void ValidaSeExisteContasCadastradas()
        {
            if (listaContas.Count <= 0)
            {
                throw new DomainException("Não existe contas cadastradas!");
            }
        }

         private void ValidaSeContaEstaCadastrada(int idConta)
        {
            if (!listaContas.Exists(x => x.Id == idConta)) 
            {
                throw new DomainException("A conta de número " + idConta + " não está cadastrada!");    
            }
        }
    }
}