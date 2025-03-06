# Informe del Proyecto Konoha Maze 

## Ejecución del proyecto

Para ejecutar el proyecto Konoha Maze, siga los siguientes pasos:
1. Navegue a la carpeta 'bin' dentro del directorio del proyecto.
2. Ejecute el archivo 'Konoha Maze' para iniciar el juego.

## Dependencias

1. El proyecto no consta de dependencias.

## Instrucciones

### Opciones Iniciales

Al comenzar el juego se desarrollará la introducción al mismo. Se luego mostrarán las siguientes opciones:
1. **Play**
2. **Game Information**
3. **Exit**

#### Play
Si se selecciona esta opción comenzará una nueva partida.

#### Game Information
En esta opción se presentarán:
- Objetivo del juego.
- Como jugar.
- Información sobre las trampas.
- Información sobre los personajes,

### Selección de Jugadores
Para seleccionar su jugador bastará con escribir el nombre de este.

## Acerca del Juego

Es un juego para dos jugadores, el cual trata de encontrar al villano y para esto es necesario salir del bosque donde se desarrolla el juego. Cabe destacar que a pesar de ser un juego en equipo ganará el primero en llegar a la salida.

### Ojetivo del Juego
Llegar a la salida marcada con una "**w**".
 
### Controles
- **Desplazamiento**: Flechas del teclado.
- **Ejecutar Habilidad**: Tecla "**A**".
- **Pasar Turno**: Tecla "**ENTER**".

### Habilidades Disponibles 

- **Sustitution**: Intercambia la posición de los jugadores en el tablero.
- **Byakugou**: Concentra shakra en forma de fuerza para destruir obstáculos.
- **Shadow Clon**: Ofrece inmunidad ante trampas durante un tiempo determinado.
- **Sharingan Effect**: Usa su poder visual para copiar la habilidad del otro jugador.
- **Byakugan**: Muestra las trampas colocadas en el campo de batalla.
- **Shintenshin**: Ofrece la posibilidad de controlar al adversario.

### Trampas

- **Neblina**: El jugador que cae en ella pierde un turno.
- **Trampa Terrestre**: El jugador que cae en ella pierda cinco turnos, a menos que sea rescatado.
- **Pergamino Trampa**: Devuelve a al jugador que cae en ella cinco posiciones atrás.

## Acera de las Clases Implementadas
áéíó
### Lógica

- '**Board**': Consta de métodos para la inicialización del tablero aleatoriamente, validación de obstáculos.
- '**Box**': Consta de una enumeración para los distintos tipos de casillas. 
- '**Lee**': Consta de métodos para que el tablero se totalmente alcanzable.
- '**Play**': Consta del metodo que desarrolla el juego.
- '**Player**': Consta de las propiedades que contiene el tipo personaje, un constructor de clase y métodos como: opciones que posee el jugador, validación de las posiciones del jugador, movimiento y representacion de este en el tablero y el ejecutor de habilidades.
- '**Effect**': Consta de los métodos de las habilidades de cada personaje.
- '**Tramp**': Consta del método que ejecuta los efectos de las trampas.

### Visual
- '**Start End**': Consta de los métodos que introducen y finalizan el juego, el menú de opciones, la informacion del juego ademas de métodos para imprimir el tablero y borrar los comentarios.

## Flujo del Juego

El flujo de Konoha Maze es el siguiente:
1. Los jugadores son recibidos por una pantalla de inicio gestionada por 'Start End' donde se muestra la trama principal del juego.
2. Se accede a un menú donde los jugadores podrán elegir entre:
   - Play
   - Game Information 
   - Exit
3. A continuación cada jugador podrá elegir el personaje a usar, utilizándose el 'player construcor' para configurar sus habilidades atendiendo a qué personaje es.
4. Luego se inicializan los componentes del juego: primero se inicializa el tablero del juego haciendo uso del método 'TypeOfBox' de 'Board' y, a partir de este, se generan un tablero mask para los obstáculos y un trampBoard para las trampas.
6. El método 'Jugar' de 'Play' se encarga de gestionar el sistema de turnos, si un jugador a caído en una trampa o no, si es posible hacer uso de la habilidad y si el jugador ha llegado o no a la meta.
7. En el método 'Jugar' después de verificarse el sistema de turnos, se utilizan los métodos 'PlayerOptions' para que el jugador elija que desea hacer en su turno:
   - Si desea moverse se llamará al método 'MovePlayer' que se encarga de gestionar esta acción.
   - Si desea hacer uso de la habilidad se llamará al método 'EjecutarEfecto' que se encarga de gestionar los efectos de los diferentes personajes.