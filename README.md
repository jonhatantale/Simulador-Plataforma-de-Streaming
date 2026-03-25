Información personal
- Curso: Pensamiento Computacional
- Facultad: Ingeniería en Informática y Sistemas
- Nombre: Jonhatan Orlando Talé de León
- Carné: 1612926
- Docente: Ing. Manuel Rojas

Simulador de Plataforma de Streaming
Sistema de consola hecho en C# que ayuda al equipo de una plataforma de streaming, el programa 
decide si un contenido puede publicarse o no aplicando reglas de forma automática.

Descripción
El programa revisa uno a uno los contenidos y toma una decisión final según reglas fijas del sistema.
Cada contenido se analiza según su tipo. También se considera la duración, clasificación, horario de transmisión y nivel de producción.
Las posibles decisiones finales son:

- Publicar
- Publicar con ajustes
- Enviar a revisión
- Rechazar.

Requisitos
- Visual Studio 2022 o superior
- SDK de .NET 8

Instrucciones para ejecutar el programa
1. Clonar el repositorio:
``` git clone https://github.com/jonhatantale/ProyectoStreaming.git ```
2. Abrir el archivo `ProyectoStreaming.sln` en Visual Studio
3. Compilar el proyecto con `Ctrl + Shift + B`
4. Ejecutar el programa con `F5`

Estructuras utilizadas en el código
- `switch` para el menú principal
- `do-while` para mantener el sistema activo
- `while` para validar entradas del usuario
- `if/else` anidado para la validación técnica
- `if/else` encadenado para la clasificación de impacto
- Métodos estáticos para organizar el código

Opciones disponibles en el menú principal
| Opción |           Descripción             |
|--------|-----------------------------------|
|    1   | Evaluar contenido                 |
|    2   | Mostrar reglas del sistema        |
|    3   | Mostrar estadísticas de la sesión |
|    4   | Reiniciar estadísticas            |
|    5   | Salir                             |
