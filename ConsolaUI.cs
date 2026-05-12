using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUI
    {
        private readonly MotorAhorcado _motor;

        public ConsolaUI(MotorAhorcado motor)
        {
            _motor = motor;
        }

        public void MostrarTablero()
        {
            Console.Clear();

            // Título con color
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("===========================");
            Console.WriteLine("       JUEGO: AHORCADO     ");
            Console.WriteLine("===========================");
            Console.ResetColor();

            MostrarAhorcado();

            // Información del estado
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nIntentos restantes: ");
            Console.ForegroundColor = _motor.IntentosRestantes <= 2 ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine(_motor.IntentosRestantes);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Letras usadas: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Join(", ", _motor.LetrasUsadas).ToUpper());
            Console.ResetColor();

            // Palabra secreta
            Console.Write("\nPalabra: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (char c in _motor.PalabraSecreta)
            {
                Console.Write(_motor.LetrasUsadas.Contains(c) ? $" {char.ToUpper(c)} " : " _ ");
            }
            Console.ResetColor();
            Console.WriteLine("\n");
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
            System.Threading.Thread.Sleep(1000); // Pausa breve para que el usuario lea el mensaje
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
            // Cambiamos el color del dibujo según los intentos restantes
            Console.ForegroundColor = _motor.IntentosRestantes <= 2 ? ConsoleColor.Red : ConsoleColor.DarkYellow;

            string[] etapas = new string[]
            {
                "  +---+\n  |   |\n      |\n      |\n      |\n      |\n=========", // 0 fallos
                "  +---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========", // 1 fallo
                "  +---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========", // 2 fallos
                "  +---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========", // 3 fallos
                "  +---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========", // 4 fallos
                "  +---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========", // 5 fallos
                "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n========="  // 6 fallos
            };

            // Aseguramos que el índice no se salga de rango
            int indice = Math.Clamp(6 - _motor.IntentosRestantes, 0, 6);
            Console.WriteLine(etapas[indice]);
            Console.ResetColor();
        }
    }
}