using System;
class Program
{
    static void Main()
    {
        Console.Write("Digite o CNPJ: ");
        string cnpj = Console.ReadLine();

        // Remover caracteres não numéricos
        cnpj = RemoverNaoNumericos(cnpj);

        // Verificar se o CNPJ tem 14 dígitos
        if (cnpj.Length != 14)
        {
            Console.WriteLine("CNPJ inválido. O CNPJ deve ter 14 dígitos.");
            return;
        }

        // Verificar se todos os dígitos são iguais (caso especial)
        if (TodosDigitosIguais(cnpj))
        {
            Console.WriteLine("CNPJ inválido. Todos os dígitos são iguais.");
            return;
        }

        // Verificar o primeiro dígito verificador
        int[] multiplicadoresPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int primeiroDigitoVerificador = CalcularDigitoVerificador(cnpj, multiplicadoresPrimeiroDigito);

        if (primeiroDigitoVerificador != int.Parse(cnpj[12].ToString()))
        {
            Console.WriteLine("CNPJ inválido. O primeiro dígito verificador não coincide.");
            return;
        }

        // Verificar o segundo dígito verificador
        int[] multiplicadoresSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int segundoDigitoVerificador = CalcularDigitoVerificador(cnpj, multiplicadoresSegundoDigito);

        if (segundoDigitoVerificador != int.Parse(cnpj[13].ToString()))
        {
            Console.WriteLine("CNPJ inválido. O segundo dígito verificador não coincide.");
            return;
        }

        Console.WriteLine("CNPJ válido.");
    }

    static string RemoverNaoNumericos(string valor)
    {
        string apenasDigitos = "";
        foreach (char c in valor)
        {
            if (char.IsDigit(c))
            {
                apenasDigitos += c;
            }
        }
        return apenasDigitos;
    }

    static bool TodosDigitosIguais(string valor)
    {
        for (int i = 1; i < valor.Length; i++)
        {
            if (valor[i] != valor[0])
            {
                return false;
            }
        }
        return true;
    }

    static int CalcularDigitoVerificador(string cnpj, int[] multiplicadores)
    {
        int soma = 0;
        int indice = 0;
        while (indice < multiplicadores.Length)
        {
            int digito = int.Parse(cnpj[indice].ToString());
            soma += digito * multiplicadores[indice];
            indice++;
        }

        int resto = soma % 11;
        int digitoVerificador = resto < 2 ? 0 : 11 - resto;

        return digitoVerificador;


    }
}