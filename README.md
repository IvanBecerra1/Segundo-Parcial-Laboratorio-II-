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
> Utilice Interfaces en varias ocaciones:
  IRepositorio, una interfaz dedicada al crud que se lleva acabo en los     
     distintas entidades, lo implemente porque es buena practica y porque y        tambien el hecho de que cada entidad que este relacionada al crud, lleva 
     la misma funcionalidad, sabiendo que la implementacion logica cada uno 
     pueda variar 

  IJuegoCartas, en esta interfaz implemente las funcionalidades que llevaria     un juego de cartas, independientemente si es de Uno, EscobaQuince, porque en 
  si las funciones basicas/principales es compartida entre los juegos de 
  cartas.

### Delegados
> Implemente los delegados en la parte de las funcionalidades del juego, para llevar acabo verificaciones que tendria que hacer constante, esto me permitio simplemente llamar al delegado y realizar la tarea. Tambien lleve acabo delegados cortos para verificar y validar datos del formulario 

### Task 
> Lleve acabo el uso de Task para poder abrir varias salas sin que perjudique ni me condicione la principal, tambien implemente en el momento que un jugador lanza una carta, le de 5 segundos antes de cambiar de mano para que pueda realizar alguna accion.

### Eventos
> Lleve acabo los eventos para invocar metodos que estan implementadas en otra clase, en especial cuando aplique el modelo MVP. No obstante tambien utilice en los formularios, mas especificamente en partes de las propiedades, debido a que necesitaba llamar a una funcionalidad cuando se le asigne valor a una propiedad.

## Propuesta de valor agregado
> Mi propuesta esta vez no fue enfocarme en el diseño del formulario, si no que esta vez me puse a investigar como mejorar y crear codigo mas limpio y mejor estruturado. 
### SOLID
> Lleve los principios de SOLID, para estructurar mejor la parte de entidades, puntualmente me aplique el Principio de Responabilidad Unica
en las parte de las funcionalidades de cartas. Este principio dice que una entidad debe tener una unica responsabilidad, en este caso
mi entidad Carta.cs, solo tendra el comportamiento principal de clase, pero sus funcionalidades estaran implementadas en otra clase, llamada UnoServicio, donde a la vez estara establecida con el contrato de IJuegosCarta. 
> Principio de inversion de Dependencias: este es otro principio de SOLID, donde basicamente dice que una clase de alto nivel no dependa de uno de bajo nivel, y que se utilizara como dependencia a abstracciones (interfaces o clases abstractas). Implemente el principio en mi clase Sala, mi razonamiento fue que la clase no es necesario que de penda de la clase Uno (Juego del Uno).
> Cabe aclarar que seguir los principios SOLID no es algo que es obligatorio y tampoco es una regla a seguir. Pero me fue interesante aplicarlo en este parcial, me ayudo y me dejo pensando mas de una vez

### DRY
> Trate de seguir este principio, que dice basicamente No te repitas, referenciando a no crear metodos repetidos e intentar reutilizar codigo lo que mas puedas. Lleve entonces acabo crear Metodos especificos, que solo cumplan una funcion y nada mas. Puede verse en mi clase UnoServicio.

### Patron Singleton
> Investige sobre este patron, basicamente es hacer que una clase en concreta solo pueda ser instanciada una unica vez y que si ya esta instanciada, te la devuelve esta instancia. Debe tener muchas mas funcionalidades, me parecio muy interesante... lo aplique para restrigir la instancia del formulario Estaditicas, para restriguir su instancia y evitar que se habran multiples ventanas de este tipo.

### Modelo Vista Presentador
> Es un Patron de diseño para el desarrollo de Applicaciones, mas enfocado en los formularios de windows form. Este patron hace que se divida en partes, por un lado la vista (parte visual), y por otro lado el manejo de entidades (modelo), este patron trabaja con un principio de Solid, el de Inversion de dependencias, es decir se utiliza abstracciones, mas puntualmente interfaces.
Lleve entonces una implemenetacion, para cada formulario (vista) tiene su contrato (interfaz) que a la vez tendra una clase (presentador) que sera la encargada de manejar las funcionalidades entre la vista y la logica de negocio (manejo de entidades/modelo), ya que el contrato / interfaz tendra las funcionalidades que se van a comunicar con la clase presentador.

## Conclusion: Trate de aplicar buenas practicas para el desarrollo de esta App, independientemente como los haya realizado, me divirtio y me intereso mucho el tema de como diseñar y estructurar un proyecto, es algo que aun siento que estoy "verde", pero llevar acabo estas practicas me hizo ver el codigo de diferente forma.
