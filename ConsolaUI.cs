using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUI
    {

        private readonly MotorAhorcado? _motor;

        public ConsolaUI(MotorAhorcado? motor)
        {
            _motor = motor;
        }

        public string PedirCategoria()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================");
            Console.WriteLine("   SELECCIONA UNA CATEGORÍA    ");
            Console.WriteLine("===============================");
            Console.ResetColor();

            Console.WriteLine("\n1. Arquitectura");
            Console.WriteLine("2. POO");
            Console.WriteLine("3. .NET");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n👉 Elige una opción (1-3): ");
            Console.ResetColor();

            string opcion = Console.ReadLine();
            return opcion switch
            {
                "1" => "Arquitectura",
                "2" => "POO",
                "3" => ".NET",
                _ => "POO" 
            };
        }

        public void MostrarTablero()
        {
            if (_motor == null) return;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("===========================");
            Console.WriteLine("       JUEGO: AHORCADO     ");
            Console.WriteLine("===========================");
            Console.ResetColor();

            MostrarAhorcado();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nIntentos restantes: ");
            Console.ForegroundColor = _motor.IntentosRestantes <= 2 ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine(_motor.IntentosRestantes);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Letras usadas: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Join(", ", _motor.LetrasUsadas).ToUpper());
            Console.ResetColor();

            Console.Write("\nPalabra: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (char c in _motor.PalabraSecreta)
            {
                Console.Write(_motor.LetrasUsadas.Contains(c) ? $" {char.ToUpper(c)} " : " _ ");
            }
            Console.ResetColor();
            Console.WriteLine("\n");

            if (_motor.MostrarPista)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("💡 PISTA:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"La palabra empieza con: '{char.ToUpper(_motor.PalabraSecreta[0])}'");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public char PedirLetra()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("👉 Ingresa una letra: ");
            string input = Console.ReadLine();
            Console.ResetColor();

            if (string.IsNullOrWhiteSpace(input)) return ' ';
            return input.ToLower()[0];
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n[!] {mensaje}");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
        }

        public bool PreguntarOtraVez()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n¿Quieres jugar otra vez? (s/n): ");
            Console.ResetColor();
            return Console.ReadLine()?.ToLower() == "s";
        }

        private void MostrarAhorcado()
        {
            if (_motor == null) return;

            Console.ForegroundColor = _motor.IntentosRestantes <= 2 ? ConsoleColor.Red : ConsoleColor.DarkYellow;

            string[] etapas = new string[]
            {
                "  +---+\n  |   |\n      |\n      |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n========="
            };

            int indice = Math.Clamp(6 - _motor.IntentosRestantes, 0, 6);
            Console.WriteLine(etapas[indice]);
            Console.ResetColor();
        }
    }
}