# Juego del Ahorcado y Viborita

Este es un proyecto educativo de consola desarrollado en **C#** y **.NET**. El objetivo principal fue transformar una aplicación monolítica en una arquitectura desacoplada y mantenible aplicando los principios **SOLID**.

## Características
- **Arquitectura Limpia:** Separación total entre lógica de negocio, interfaz de usuario y persistencia.
- **Sistema de Categorías (Ahorcado):** El jugador puede elegir entre *Arquitectura*, *POO* o *.NET*.
- **Pistas Dinámicas:** El sistema ofrece una pista inteligente cuando quedan 3 intentos o menos en el Ahorcado.
- **Motor de Viborita:** Implementación del clásico "Snake" con lógica de colisiones y crecimiento mediante `LinkedList`.
- **Interfaz Colorida y Fluida:** Uso de `ConsoleColor` y manejo de coordenadas del cursor para evitar el parpadeo en la terminal.

## Arquitectura (Principios SOLID Aplicados)

| Principio | Aplicación en este proyecto |
| :--- | :--- |
| **SRP** | Se dividió el código en motores de juego (`MotorAhorcado`, `MotorViborita`), interfaces de usuario específicas y repositorios de datos. |
| **OCP** | El sistema permite agregar nuevos juegos (como se hizo con la Viborita) o nuevos repositorios sin modificar el código existente. |
| **ISP** | Los motores implementan interfaces específicas (`IMotorJuego`), asegurando que cada componente solo use lo que necesita. |
| **DIP** | El flujo principal no depende de clases concretas, sino de abstracciones, facilitando el intercambio de motores de juego. |

## 🛠 Estructura del Proyecto
- `Program.cs`: Orquestador que gestiona el menú principal y el flujo entre ambos juegos.
- `MotorAhorcado.cs` / `MotorViborita.cs`: Reglas de negocio, control de intentos, movimiento y colisiones.
- `ConsolaUI.cs` / `ConsolaUIViborita.cs`: Manejo de entradas, salidas y renderizado optimizado para cada juego.
- `IRepositorioPalabras.cs`: Contrato para la obtención de datos del Ahorcado.
- `PalabrasEnMemoria.cs`: Implementación de palabras filtradas por categoría.

##  Cláusula de Uso de IA
Este proyecto ha sido desarrollado con el apoyo de **Gemini (Inteligencia Artificial)**. 
- La IA fue utilizada para la **refactorización de código**, aplicacion de colores en la consola y para mejorar la experiencia de usuario, pero no para generar la lógica del juego ni el diseño de la arquitectura. 


