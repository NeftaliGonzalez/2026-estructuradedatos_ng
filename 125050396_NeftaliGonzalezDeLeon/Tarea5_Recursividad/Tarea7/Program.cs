using System;

namespace ColaCircularApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una cola con capacidad para 5 datos
            ColaCircular miCola = new ColaCircular(5); 
            int opcion;

            do
            {
                Console.WriteLine("\n--- MENÚ: COLA CIRCULAR ---");
                Console.WriteLine("1. Encolar (Insertar dato)");
                Console.WriteLine("2. Desencolar (Eliminar dato)");
                Console.WriteLine("3. Mostrar Cola");
                Console.WriteLine("4. Salir");
                Console.Write("Elige una opción: ");
                
                // Leemos la opción del usuario
                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingresa un número entero: ");
                        if (int.TryParse(Console.ReadLine(), out int numero))
                        {
                            miCola.Insertar(numero);
                        }
                        break;
                    case 2:
                        miCola.Eliminar();
                        break;
                    case 3:
                        miCola.Mostrar();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 4);
        }
    }

    class ColaCircular
    {
        int[] datos;
        int frente, final, contador, capacidad;

        // Constructor
        public ColaCircular(int tam)
        {
            capacidad = tam;
            datos = new int[capacidad];
            frente = 0; 
            final = -1; 
            contador = 0;
        }

        // Operación Básica 1: Insertar (Encolar)
        public void Insertar(int valor)
        {
            if (contador == capacidad)
            {
                Console.WriteLine("Error: La cola circular está LLENA.");
                return;
            }
            
            // El módulo (%) hace que el final dé la vuelta al principio si llega al tope
            final = (final + 1) % capacidad;
            datos[final] = valor;
            contador++;
            Console.WriteLine($"-> Se insertó el número {valor}.");
        }

        // Operación Básica 2: Eliminar (Desencolar)
        public void Eliminar()
        {
            if (contador == 0)
            {
                Console.WriteLine("Error: La cola circular está VACÍA.");
                return;
            }

            int valorEliminado = datos[frente];
            // El frente también avanza y da la vuelta con el módulo (%)
            frente = (frente + 1) % capacidad;
            contador--;
            Console.WriteLine($"-> Se eliminó el número {valorEliminado}.");
        }

        // Operación  3: Mostrar
        public void Mostrar()
        {
            if (contador == 0)
            {
                Console.WriteLine("La cola está vacía.");
                return;
            }

            Console.Write("Estado actual de la cola: ");
            for (int i = 0; i < contador; i++)
            {
                // Calculamos la posición real para imprimir en orden
                int posicionReal = (frente + i) % capacidad;
                Console.Write($"[{datos[posicionReal]}] ");
            }
            Console.WriteLine();
        }
    }
}