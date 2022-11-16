# Juego de cartas: El Uno

## Sobre mi
------------
> Soy Ivan estudiante de la Tecnicatura Universitaria en Programacion en la facultad UTN Regional Avellaneda. 
Mi experiencia sobre esta aplicacion fue buena, esta vez me senti mejor preparado para realizar 
el desarrollo e implementar logica correspondiente, pero aun asi fue un desafio el proyecto.

## Resumen
------------
Se trata el desarrollo de una aplicacion de juego de cartas, en este caso
el juego Uno, un juego donde tiene reglas basicas
* Se reparten 7 cartas a cada jugador
* 4 Colores de cartas (Rojo, Azul, Verde, Amarillo)
* 5 Cartas especiales
  - Roba dos: Hace que el jugador siguiente agarre dos cartas y pierda el turno
  - Roba cuatro: hace que el jugador siguiente agarre cautro cartas y pierda el turno
  - Invertir ronda: invierte el sentido de la ronda
  - Cambio de color: Cambia el color de la carta que este en mesa
  - Saltear: Hace perder el turno al siguiente jugador
  
Se gana cuando un jugador se quede sin cartas, o tenga menos cartas que el resto
una vez que la ronda finalizo.

## Diagrama de Clases

### Diagrama del Modelo de entidades
[![diagrama1.png](https://i.postimg.cc/YCJt4gXp/diagrama1.png)](https://postimg.cc/gxqCQwF5)

[![diagrama2.png](https://i.postimg.cc/WzWvsJFc/diagrama2.png)](https://postimg.cc/K3MVNjD0)

### Diagrama de Test Unitarios
[![Diagrama-Test-Unitarios.png](https://i.postimg.cc/qRGrZFpR/Diagrama-Test-Unitarios.png)](https://postimg.cc/BLtRjML9)

### Diagrama de MVP En Formulario
[![Diagrama-Formulario.png](https://i.postimg.cc/QN0sQv6Y/Diagrama-Formulario.png)](https://postimg.cc/F1d2mCX0)

### Diagrama de Base De datos 
[![diagrama-Base-Datos.png](https://i.postimg.cc/XJW3LWSm/diagrama-Base-Datos.png)](https://postimg.cc/gwgfcf0H)


## Justificacion Tecnica

### SQL
> Se utilizo SQL Server, implemente una relacion de Uno a Uno en la tabla jugador, con estadistica, porque un jugador solo puede tener una estadistica.
Implemente la relacion de Muchos a Muchos en la tabla Partidas con Jugadores, denominandose Partidas_Jugadores, por que una partida puede tener varios jugadores y un jugador puede estar asociado en varias partidas.

### Excepciones
> Genere dos excepciones personalizadas, por convencion es buena practica tener en un proyecto excepciones propias.

### Genericos
> Utilice los genericos en parte del codigo donde el metodo/funcionalidad es considerado Generico. Lo implemente en la interfaz del CRUD de Sql y en la Interfaz de funcionalidades de Cartas. En el crud porque los parametros y valores de retorno pueden ser de cualquier entidad, y en las cartas porque si bien tengo solo el CartasUno como entidad, tranquilamente podria ir CartaEscoba, o CartasTruco.

### Serializacion
> Utilice la Serializacion JSON para guardar las cartas que se crean, para evitar que cada vez que se inicie la app o se cree una Sala, se evite crear nuevamente las cartas. El Json me permitio guardar una lista de cartas y poder leerlas cuando se inice una partida.

### Escritura de Archivos
> Utilice la escritura de archivos mas que nada para almacenar Logs/Acciones que se producen en la Sala de juego

### Interfaces
> Utilice Interfaces en varias ocaciones
  1. IRepositorio, una interfaz dedicada al crud que se lleva acabo en los     
     distintas entidades, lo implemente porque es buena practica y porque y        tambien el hecho de que cada entidad que este relacionada al crud, lleva 
     la misma funcionalidad, sabiendo que la implementacion logica cada uno 
     pueda variar 

