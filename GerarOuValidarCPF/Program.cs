using System;

namespace GerarOuValidarCPF
{
    class Program
    {
        static void Main(string[] args)
        {
            GeraOuValidaCPF g = new GeraOuValidaCPF();

            //Informar "gera" para GERAR ou "número do cpf sem pontos e traços" para VALIDAR
            
            Console.WriteLine("Insira o CPF (somente números) ou escreva 'gera' para gerar um novo CPF");

            var comando = Console.ReadLine();

            if(comando != "gera" && comando.Length != 11)
            {
                Console.WriteLine("Inválido");
            }
            else
            {
                Console.WriteLine(g.GerarOuValidarCPF(comando));
            }
        }
    }
}
