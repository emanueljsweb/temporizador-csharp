using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Temporizador
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int LeTempo(string mensagem)
        {
            Console.WriteLine(mensagem);
            string? leitura;

            do
            {
                leitura = Console.ReadLine();
                if (leitura != null && Regex.IsMatch(leitura.ToLower(), @"\d{1,}(h|m|s)") == false)
                    Console.WriteLine("ERRO: O valor digitado é inválido, preencha no formato 99h99m99s.");
            } while (leitura == null || Regex.IsMatch(leitura.ToLower(), @"\d{1,}(h|m|s)") == false);

            leitura = leitura.ToLower();

            var stringSegundos = Regex.Match(leitura, @"\d{1,}s");
            var stringMinutos = Regex.Match(leitura, @"\d{1,}m");
            var stringHoras = Regex.Match(leitura, @"\d{1,}h");

            int segundos = 0;
            int minutos = 0;
            int horas = 0;

            if (stringSegundos.Success)
                segundos = int.Parse(stringSegundos.Value.Substring(0, stringSegundos.Length - 1));

            if (stringMinutos.Success)
                minutos = int.Parse(stringMinutos.Value.Substring(0, stringMinutos.Length - 1));

            if (stringHoras.Success)
                horas = int.Parse(stringHoras.Value.Substring(0, stringHoras.Length - 1));

            return segundos + minutos * 60 + horas * 60 * 60;

        }

        static void ExibeTempo(int tempo)
        {
            int horas = tempo / 3600;
            int minutos = tempo % 3600 / 60;
            int segundos = tempo % 60;

            Console.WriteLine($"{horas}h {minutos}m {segundos}s");
        }

        static void PreIniciar(int tempo)
        {
            Console.Clear();

            Console.WriteLine(
@"  _______
 /  12   \
|    |    |
|9   |   3|
|     \   |
|         |
 \___6___/");
            Console.WriteLine("Em breve, o temporizador será iniciado. Prepare-se!");

            Thread.Sleep(2500);
            Iniciar(tempo);
        }

        static void Iniciar(int tempo)
        {
            int tempoAtual = 0;

            while (tempoAtual <= tempo)
            {
                Console.Clear();
                ExibeTempo(tempoAtual);
                tempoAtual++;
                Thread.Sleep(1000);
            }

            Console.WriteLine("Temporizador finalizado. Pressione qualquer tecla para retornar ao menu...");
            Console.ReadKey();

        }
    }
}