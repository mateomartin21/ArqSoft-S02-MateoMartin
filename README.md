#  Ahorcado un jeugo sencillo en C# con .NET 10.0 y C# 14.0


Violaciones SOlID:
| Situación | Principio Violado | Explicación |
| :--- | :--- | :--- |
| **`Juego` controla todo:** turnos, dibujo del tablero, mensajes y selección de palabras. | **SRP** (Single Responsibility Principle) | La clase tiene **demasiadas responsabilidades**. Debería existir una separación entre la lógica de negocio, la interfaz de usuario (Consola) y el proveedor de datos (Palabras). |
| **Palabras "hardcodeadas":** Las palabras están definidas dentro del constructor de la clase. | **DIP** (Dependency Inversion Principle) | Existe una **dependencia rígida** de una lista interna. Lo correcto sería inyectar una abstracción (interfaz) que provea las palabras desde cualquier origen (archivo, DB o API). |
| **Dificultad para extender:** Para añadir nuevas variantes o modos de juego, se requiere editar la clase base. | **OCP** (Open/Closed Principle) | El código **no está cerrado a la modificación ni abierto a la extensión**. Añadir nuevas reglas obliga a alterar el código existente, aumentando el riesgo de introducir errores. |