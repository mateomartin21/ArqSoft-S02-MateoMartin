using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class Juego
    {
        private List<string> _palabras = new()
        {
            "Gael", "Joaquin", "Mateo", "Ariff", "Fernando", "Valentina", "Sofia", "Camila", "Liam", "Emma","Noah", "Olivia", "Aiden", "Ava", "Lucas", "Isabella", "Mason", "Mia", "Ethan", "Amelia","Logan", "Harper", "Elijah", "Evelyn", "James", "Abigail", "Benjamin", "Emily", "Jacob", "Ella", "Michael", "Elizabeth","Carter", "Sofia", "Alexander", "Madison", "Daniel", "Avery", "Matthew", "Sofia", "Henry", "Ella","Joseph", "Scarlett", "Samuel", "Grace", "David", "Chloe", "Carter", "Victoria", "Owen", "Riley"
        };
        private string _palabraSecreta;
        private List<char> _letrasUsadas;
        private int _intentosRestantes;

        public Juego()
        {
            var random = new Random();
            _palabraSecreta = _palabras[random.Next(_palabras.Count)];
            _letrasUsadas = new List<char>();
            _intentosRestantes = 6;
        }

        public void Jugar()
        {
            while (_intentosRestantes > 0)
            {
                MostrarTablero();

                if (VerificarVictoria())
                {
                    Console.WriteLine("\n¡Ganaste! La palabra era: " + _palabraSecreta);
                    PreguntarReinicio();
                    return;
                }

                Console.Write("\nIngresa una letra: ");
                string input = Console.ReadLine()?.ToLower();

                if (string.IsNullOrEmpty(input)) continue;

                char letra = input[0];

                if (_letrasUsadas.Contains(letra))
                {
                    Console.WriteLine("\nYa usaste esa letra. Presiona cualquier tecla para intentar otra...");
                    Console.ReadKey();
                    continue;
                }

                _letrasUsadas.Add(letra);

                if (!_palabraSecreta.ToLower().Contains(letra))
                {
                    _intentosRestantes--;
                }
            }

            MostrarTablero();
            Console.WriteLine("\nPerdiste. La palabra era: " + _palabraSecreta);
            PreguntarReinicio();
        }

        private void PreguntarReinicio()
        {
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                new Juego().Jugar();
            }
        }

        private bool VerificarVictoria()
        {
            foreach (char c in _palabraSecreta)
            {
                if (!_letrasUsadas.Contains(char.ToLower(c))) return false;
            }
            return true;
        }

        private void MostrarTablero()
        {
            Console.Clear();
            Console.WriteLine("=== AHORCADO ===");
            MostrarAhorcado();
            Console.WriteLine($"\nIntentos restantes: {_intentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(", ", _letrasUsadas)}");
            Console.Write("Palabra: ");

            foreach (char c in _palabraSecreta)
            {
                Console.Write(_letrasUsadas.Contains(char.ToLower(c)) ? $"{c} " : "_ ");
            }
            Console.WriteLine();

            // --- Lógica de Pistas ---
            if (_intentosRestantes <= 3)
            {
                // Busca la primera letra (en minúscula para comparar) que no esté en la lista
                char? letraPista = _palabraSecreta
                    .Select(c => char.ToLower(c))
                    .FirstOrDefault(l => !_letrasUsadas.Contains(l));

                if (letraPista != '\0')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n💡 PISTA: Te falta la letra '{char.ToUpper(letraPista.Value)}'");
                    Console.ResetColor();
                }
            }
        }

        private void MostrarAhorcado()
        {
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

            Console.WriteLine(etapas[6 - _intentosRestantes]);
        }
    }
}
