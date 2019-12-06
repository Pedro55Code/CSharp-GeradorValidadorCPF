using System;
using System.Collections.Generic;
using System.Text;

namespace GerarOuValidarCPF
{
    public class GeraOuValidaCPF
    {
        public string GerarOuValidarCPF(string geraOuValida)
        {
            Random gerador = new Random();

            int[,] cpf = new int[4, 11];

            for (int i = 0; i <= 8; i++)
            {
                cpf[0, i] = geraOuValida == "gera" ? gerador.Next(0, 9) : int.Parse(geraOuValida.Substring(i, 1));

                cpf[1, i] = 10 - i;
                cpf[2, i] = cpf[0, i] * cpf[1, i];

                cpf[3, 1] += cpf[2, i];
            }

            cpf[0, 9] = cpf[3, 1] % 11 == 1 || cpf[3, 1] % 11 == 0 ? 0 : 11 - (cpf[3, 1] % 11);

            for (int i = 0; i <= 9; i++)
            {
                cpf[1, i] = 11 - i;
                cpf[2, i] = cpf[0, i] * cpf[1, i];

                cpf[3, 2] += cpf[2, i];
            }

            cpf[0, 10] = cpf[3, 2] % 11 == 1 || cpf[3, 2] % 11 == 0 ? 0 : 11 - (cpf[3, 2] % 11);

            string retorno = "";

            if (geraOuValida != "gera" )
            {
                retorno = int.Parse(geraOuValida.Substring(9, 1)) == (cpf[3, 1] % 11 == 1 || cpf[3, 1] % 11 == 0 ? 0 : 11 - (cpf[3, 1] % 11)) &&
                          int.Parse(geraOuValida.Substring(10, 1)) == (cpf[3, 2] % 11 == 1 || cpf[3, 2] % 11 == 0 ? 0 : 11 - (cpf[3, 2] % 11)) ?
                          "CPF Válido" : "CPF Não Válido";

            }
            else
            {
                for (int i = 0; i <= 10; i++)
                {
                    if (i == 3 || i == 6) retorno += '.';
                    if (i == 9) retorno += '-';
                    retorno += cpf[0, i];
                }
            }

            return retorno;
        }

    }
}
