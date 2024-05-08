# Prueba Técnica - Sistema de Control de Surtidores
Este proyecto es una implementación básica de un sistema de control de surtidores en C#. El sistema simula el funcionamiento de una pista de combustible con múltiples surtidores, permitiendo realizar suministros de combustible y llevando un historial de los suministros realizados.

## Contenido del Repositorio
* Program.cs: Contiene la lógica principal del programa, incluyendo el método Main que inicializa la pista y realiza suministros de combustible de prueba.
* Surtidor.cs: Definición de la clase Surtidor, que representa un surtidor de combustible. Contiene métodos para controlar el estado del surtidor, prefijar un importe y finalizar un suministro.
* Pista.cs: Definición de la clase Pista, que gestiona múltiples surtidores y lleva un historial de los suministros realizados.
* Suministro.cs: Definición de la clase Suministro, que representa un suministro de combustible realizado, con información como el número de surtidor, fecha y hora, importe prefijado y importe surtido.

## Requisitos del Sistema
Para ejecutar este programa, es necesario tener instalado el entorno de desarrollo de .NET. Se puede utilizar Visual Studio o cualquier editor de código compatible con C#.

## Ejecución del Programa
1. Clona o descarga este repositorio en tu máquina local.
1. Abre el proyecto en tu entorno de desarrollo de .NET.
1. Compila y ejecuta el programa.
1. Observa la salida en la consola para ver el historial de suministros realizados.

## Pruebas Unitarias
El proyecto incluye pruebas unitarias utilizando el framework NUnit para verificar el funcionamiento correcto de las clases Surtidor y Pista. Las pruebas se encuentran en los archivos SurtidorTests.cs y PistaTests.cs en el proyecto de pruebas.

## Para ejecutar las pruebas:

1. Abre el proyecto de pruebas en tu entorno de desarrollo de .NET.
1. Compila y ejecuta las pruebas.
1. Verifica que todas las pruebas se ejecuten correctamente.

## Contribuciones
Este proyecto es un ejercicio de prueba técnica y no está abierto a contribuciones externas en este momento.

## Contacto
Para cualquier pregunta o comentario, no dudes en ponerte en contacto con el autor del repositorio.
