using System;

namespace ConsoleApp1
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Valor padrão não é um numero(NaN), podendo causar erros em operações.

            // Usando um switch para lidar com as opções/operações da interface
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "d":
                    result = num1 / num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                // Retorna um texto para uma opção incorreta.
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;


            // Exibe o titulo da calculadora
            Console.WriteLine("Calculadora de console em C#\r");
            Console.WriteLine("----------------------------\n");

            while(!endApp)
            {
                // Declarando e inicializando as variáveis.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Lendo o primeiro número do usuário
                Console.Write("Digite um numero e pressione ENTER: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Essa não é uma entrada válida. Por favor digite um valor inteiro: ");
                    numInput1 = Console.ReadLine();
                }


                // Lendo o segundo numero do usuário
                Console.Write("Digite um outro numero e pressione ENTER: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Essa não é uma entrada válida. Por favor digite um valor inteiro: ");
                    numInput2 = Console.ReadLine();
                }

                // Pede ao usuário a operação desejada.
                Console.WriteLine("Escolha uma operação da lista a seguir:");
                Console.WriteLine("\ta - Adição");
                Console.WriteLine("\ts - Subtração");
                Console.WriteLine("\tm - Multiplicação");
                Console.WriteLine("\td - Divisão");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Essa operação vai causar um erro!");
                    }
                    else Console.WriteLine("Seu resultado: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh não! Uma exceção ocorreu enquanto tentava fazer os cálculos!\n - Detalhes: " + e.Message);
                }

                Console.WriteLine("----------------\n");

                // Espere o usuário responder antes de fechar o aplicativo.
                Console.Write("Aperte 'n' e ENTER para fechar o aplicativo ou aperte qualquer outra tecla e enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                // Espaçamento amigável
                Console.WriteLine("\n");
            }
            return;
        }
    }
}