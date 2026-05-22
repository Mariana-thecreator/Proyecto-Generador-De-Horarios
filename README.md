# Sistema de Horarios Académicos con Grafos

## Descripción general

Este proyecto implementa un sistema de asignación de horarios académicos utilizando grafos y el algoritmo de coloreado greedy.

Cada curso es representado como un nodo y los conflictos entre cursos son representados mediante aristas en un grafo no dirigido.

El objetivo principal es asignar bloques horarios evitando conflictos entre cursos que compartan profesor, salón o grupo de estudiantes.

El proyecto fue desarrollado utilizando C# y estructuras de datos como arreglos y matrices de adyacencia.

---

# Integrantes

- Anderson León Giraldo
- Mariana López Díaz

---

# Estructura del repositorio

```txt
ProyectoGrafos/
│
├── README.md
│
├── src/
│   └── Program.cs
│
├── docs/
│   ├── documento_tecnico.md
│   └── imagenes/
│
├── data/
│   ├── prueba1.txt
│   └── cursos.txt
```

---

# Instrucciones de ejecución

## Requisitos

- Visual Studio Code
- .NET SDK instalado
- Extensión de C# para Visual Studio Code

---

## Pasos para ejecutar el programa

1. Abrir el proyecto en Visual Studio Code.

2. Abrir una terminal en la carpeta `src`.

3. Ejecutar el siguiente comando:

```bash
dotnet run
```

4. Seleccionar la opción:

```txt
1
```

para cargar un archivo de prueba.

5. Ingresar la siguiente ruta:

```txt
../data/prueba1.txt
```

6. Utilizar el menú para probar las diferentes operaciones del sistema.

---

# Funcionalidades implementadas

- Cargar cursos y conflictos desde archivo.
- Agregar y eliminar cursos.
- Agregar y eliminar conflictos entre cursos.
- Representación del grafo mediante matriz de adyacencia.
- Asignación de bloques horarios utilizando coloreado greedy.
- Validación de horarios libres de conflictos.
- Visualización de la matriz horaria final.

---

# Herramientas de apoyo utilizadas

Durante el desarrollo del proyecto se utilizaron herramientas de inteligencia artificial como apoyo académico y guía de aprendizaje.

Herramientas utilizadas:

- ChatGPT
- Claude
- Gemini