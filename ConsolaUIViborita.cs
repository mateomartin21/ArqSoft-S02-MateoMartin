using System;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUIViborita
    {
        private readonly MotorViborita _motor;

        public ConsolaUIViborita(MotorViborita motor)
        {
            _motor = motor;
        }

        public void MostrarTablero()
        {
            // Resetear cursor al inicio para evitar parpadeo (flicker)
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"=== VIBORITA ===   Puntos: {_motor.Puntos}   ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");

            for (int y = 0; y < _motor.Alto; y++)
            {
                Console.Write("|");
                for (int x = 0; x < _motor.Ancho; x++)
                {
                    // Lógica de dibujo prioritaria
                    if (_motor.Cuerpo.First() == (x, y))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@"); // Cabeza
                    }
                    else if (_motor.Cuerpo.Contains((x, y)))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("o"); // Cuerpo
                    }
                    else if (_motor.Comida == (x, y))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*"); // Comida
                    }
                    else
                    {
                        Console.Write(" "); // Espacio vacío (ESTO arregla los asteriscos)
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("|");
            }

            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");
            Console.WriteLine("Flechas: mover  |  Q: salir          ");
        }

        public ConsoleKey LeerTecla()
        {
            if (Console.KeyAvailable)
            {
                return Console.ReadKey(true).Key;
            }
            return ConsoleKey.NoName;
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
    }
}