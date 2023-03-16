# People API

## Sobre la API

- Tecnologias utilizadas
    - [.NET sdk 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
    - [Nodejs 18.0](https://nodejs.org/es/download/current/)
    - Mongo db Atlas
    - xunit 2.4.2
    - Docker 20.10.23
  
- Desarrollador
    - Maria Sol Fontenla

## Instrucciones para ejecutar la API:

1. Requerimientos previos  
- Haber instalado .NET sdk 7.0.
- Haber instalado Nodejs 18.
- Para correr la api en un contenedor se requiere tener Docker instalado y corriendo.


2. Ejecución

### Para correr api *sin contenedor*  

Podemos correr la api con el siguiente comando
```
$ dotnet run
```

Luego, accedemos a [https://localhost:7232](https://localhost:7232)

### Para correr la api en un *contenedor*

Primero construimos la imagen desde el directorio raiz
´´´
$ dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer
´´´

Luego lo corremos con el siguiente comando

´´´
$ docker run -it --rm -p 8080:80 peopleapi:1.0.0
´´´

Por último, accedemos a [https://localhost:8080](https://localhost:8080)
1. Test

Para correr los tests, ejecutar el siguiente comando desde la ruta del proyecto
```
$ dotnet test
```


### Detalles de implementacion

* Patrones de diseño utilizados

#### Singleton
Se utilizo este patron de diseño para poder tener una unica instancia global. Se utilizo para las clases de 
* PeopleRepository
* PeopleMongoService
* PersonManager

#### Repository
Se utilizo este patron para separar el acceso a datos de la capa de negocio mediante la clase de PeopleRepository.


### Preguntas

- Diferencia entre filtrar los datos desde el motor de base de datos y hacer el filtro en frontend sin resolverlo a nivel BD.

La diferencia es que los datos se procesan una vez desde la consulta a la base de datos y el frontend solo muestra los resultados. Además, se traduce en menos datos siendo transmitidos desde el backend al frontend cuando esto se hace desde el motor de base de datos.

- Qué tipos de validaciones puede tener un sistema? dónde se debieran implementar?

Un sistema puede tener validaciones de datos y de autenticacion.
En el caso de las validaciones de dato por tipo (entero o de tipo string por ejemplo) se deben hacer desde el frontend porque sino al enviar los datos al backend se deberia contemplar todo tipo de datos, lo cual hace al sistema menos robusto.
En el caso de las validaciones por regla de negocio, se deben hacer en el backend ya que es el que conoce el negocio. 
En el caso de la autenticacion, tambien es el backend. Sino se podria modificar codigo desde el cliente para enviar al backend informacion falsa.

Otras preguntas

1. ¿Qué es un ORM? Ventajas y desventajas.
Un ORM es un modelo que permite mapear registros de una base de datos relacional a un modelo de objetos.  
Las ventajas son que aporta facilidad y seguridad al acceso de datos, mientras que la desventaja es que puede disminuir el rendimiento cuando se procesa un volumen alto de datos porque es otra capa mas que se agrega al sistema

1. Diferencias entre: cliente de BD vs driver de conexión de BD vs motor de base de datos  (Dar ejemplos)


3. ¿Qué es una API REST?

Una API rest es una interfaz de aplicaciones web que se acopla a las caracteristicas de las arquitecturas de tipo REST. Estas caracteristicas son:
* Arquitectura cliente servidor
* Es un sistema sin estado. Los recursos se procesan sin tener en cuenta los anteriores.
* Es un sistema en capas.
* Es cacheable.


1. Diferencias entre un test unitario vs un test de integración
La diferencia es que en un test unitario se prueba un componente aislado de un sistema, abstrayendose del funcionamiento de los demas componentes mientras que en un test de integracion se prueban todos los componentes funcionando en conjunto.  

5. ¿Para que se usan los mocks en los unit test? 
Los mocks se usan para abstraerse de los servicios que pueda estar usando un componente para asi probar que este funciona sin depender del funcionamiento de dichos servicios.


