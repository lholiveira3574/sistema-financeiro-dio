using sistema_financeiro_dio.Enums;

namespace sistema_financeiro_dio.Entidades
{
    public class Conta 
    {
        public int Id { get; private set; }
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(int id, TipoConta tipoConta, double saldo, double credito, string nome)
		{
            this.Id = id;
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
		}

        public bool Sacar(double valorSaque)
		{
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                return false;
            }
            this.Saldo -= valorSaque;
            return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;
		}

		public bool Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
                return true;
            }

            return false;
		}

        public override string ToString()
		{
            return  "Numero da Conta: " + this.Id + " | " +
                    "Tipo: " + this.TipoConta + " | " +
                    "Nome: " + this.Nome + " | "+
                    "Saldo: " + this.Saldo + " | " +
                    "Crédito: " + this.Credito;

		}
    }
}