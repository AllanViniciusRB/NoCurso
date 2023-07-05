using System;

internal class Program
{
    /*Validar CPF e CNPJ
    Mostrar se o CPF ou CNPJ é ou não válido 
    Métodos: 
    1. Inserir CPF ou CNPJ
    2. Ver se a estrutura (só número e total de caracteres está correto) 
    3. Conversão para int e conta 
    4. Formatação e retorno
*/
    static bool ValidarCNPJ(string cnpj)
    {
        if (cnpj.Length != 14)
        {
            Console.WriteLine("CNPJ Inválido! ");
            return false;
        }
        else
        {
            int[] peso1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] peso2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma1 = 0, soma2 = 0;
            int resto1 = 0, resto2 = 0;

            for (int i = 0; i < 12; i++)
            {
                soma1 += (cnpj[i] - '0') * peso1[i];
            }
            resto1 = soma1 % 11;
            resto1 = (resto1 < 2) ? 0 : 11 - resto1; // Se o resto for < 2, o resto será 0, caso contrário, 11 - resto

            if (resto1 != (cnpj[12] - '0'))
            {
                return false;
            }

            for (int i = 0; i < 13; i++)
            {
                soma2 += (cnpj[i] - '0') * peso2[i];
            }
            resto2 = soma2 % 11;
            resto2 = (resto2 < 2) ? 0 : 11 - resto2;

            return resto1 == (cnpj[12] - '0') && resto2 == (cnpj[13] - '0'); // A subtração '0' é feita para converter o caractere em um valor numérico.
        }
    }
    static string FormatarCNPJ(string cnpj)
    {
        return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12)}";
    }

    static void Main(string[] args)
    {
        string cnpj;
        while (true)
        {
            Console.WriteLine("Insira seu CNPJ: ");
            cnpj = Console.ReadLine();
            if (ValidarCNPJ(cnpj))
            {
                Console.WriteLine("CNPJ Válido!");
                Console.WriteLine($" O CNPJ foi: {FormatarCNPJ(cnpj)}");
                break;
            }
            else
            {
                Console.WriteLine("CNPJ Inválido! ");
            }
        Console.ReadLine();
    }
}
}
