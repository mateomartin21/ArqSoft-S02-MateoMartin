using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly Dictionary<string, List<string>> _categorias = new()
        {
            { "Arquitectura", new List<string> { "arquitectura", "componente", "descomposicion", "dependencia", "acoplamiento" } },
            { "POO", new List<string> { "polimorfismo", "encapsulamiento", "herencia", "abstraccion", "clase" } },
            { ".NET", new List<string> { "ensamblado", "namespace", "interfaz", "delegado", "middleware" } }
        };

        private string _categoriaSeleccionada;

        public PalabrasEnMemoria(string categoria)
        {
            _categoriaSeleccionada = categoria;
        }

        public string ObtenerPalabraAleatoria()
        {
            var lista = _categorias[_categoriaSeleccionada];
            return lista[new Random().Next(lista.Count)];
        }
    }
}