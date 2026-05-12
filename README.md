#  Juego del Ahorcado 

Este es un proyecto educativo de consola desarrollado en **C#** y **.NET**. El objetivo principal fue transformar una aplicación monolítica en una arquitectura desacoplada y mantenible aplicando los principios **SOLID**.

##  Características
- **Arquitectura Limpia:** Separación total entre lógica de negocio, interfaz de usuario y persistencia.
- **Sistema de Categorías:** El jugador puede elegir entre *Arquitectura*, *POO* o *.NET*.
- **Pistas Dinámicas:** El sistema ofrece una pista inteligente cuando quedan 3 intentos o menos.
- **Interfaz Colorida:** Uso de `ConsoleColor` para una experiencia de usuario mejorada en la terminal.

##  Arquitectura (Principios SOLID Aplicados)

| Principio | Aplicación en este proyecto |
| :--- | :--- |
| **SRP** | Se dividió el código en `MotorAhorcado` (lógica), `ConsolaUI` (vista) y `PalabrasEnMemoria` (datos). |
| **OCP** | El sistema permite agregar nuevas categorías o tipos de repositorios (ej. una base de datos) sin modificar el motor del juego. |
| **DIP** | El `MotorAhorcado` no depende de una clase fija, sino de la interfaz `IRepositorioPalabras`. |

## 🛠 Estructura del Proyecto
- `Program.cs`: Orquestador del flujo del juego.
- `MotorAhorcado.cs`: Reglas de negocio y control de intentos.
- `ConsolaUI.cs`: Manejo de entradas, salidas y renderizado del dibujo.
- `IRepositorioPalabras.cs`: Contrato para la obtención de datos.
- `PalabrasEnMemoria.cs`: Implementación de palabras filtradas por categoría.

##  Cláusula de Uso de IA
Este proyecto ha sido desarrollado con el apoyo de **Gemini (Inteligencia Artificial)**. 
- La IA fue utilizada para la **refactorización de código**, aplicacion de colores en la consola y para mejorar la experiencia de usuario, pero no para generar la lógica del juego ni el diseño de la arquitectura. 


