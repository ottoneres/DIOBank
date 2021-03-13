using System;

namespace DIO.Bank
{
    public class Conta
    {
        private string Nome { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private TipoConta TipoConta { get; set; }
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        // Aqui colocamos um bool para gerar um alerta caso não houver saldo
        // suficiente para sacar a quantia informada
        public bool Sacar(double valorSaque)
        {
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }
        // aqui vamos reutilizar o método de Sacar e de Depositar já
        // que uma transferência basicamente realiza esses procedimentos
        // e a lógica já foi construída
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        // Aqui estamos sobrescrevendo a classe tradicional .ToString() de objetos
        // que apresentam o nome da classe, para exibir as informações bancárias da conta.
        // Para sobrescrever, usamos o override
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;

            return retorno;
        }


    }
}