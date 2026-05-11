using System;
using System.Collections.Generic;
using System.IO;

namespace MusicStore
{
    // ============================================================
    // PROGRAMA PRINCIPAL - MusicStore
    // ============================================================
    // Ejercicio 2: Listas, Strings, Fechas y Ficheros
    // ============================================================
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("===========================================");
            Console.WriteLine("       MUSICSTORE - TIENDA DE MUSICA       ");
            Console.WriteLine("===========================================");
            Console.WriteLine();

            // ========================================================
            // EJERCICIO 2.1 - Trabajar con la lista
            // ========================================================

            // a) Crear lista e insertar 3 albumes con Add()
            List<Album> albumes = new List<Album>();
            albumes.Add(new Album("Master of Puppets", "Metallica", 1986, true));
            albumes.Add(new Album("Thriller", "Michael Jackson", 1982, false));
            albumes.Add(new Album("Black Album", "Metallica", 1991, true));

            // b) Mostrar todos con foreach + ToString()
            Console.WriteLine(">> 2.1.b - Listado completo de albumes:");
            Console.WriteLine("-------------------------------------------");
            foreach (Album a in albumes)
            {
                Console.WriteLine(a.ToString());
            }
            Console.WriteLine();

            // c) Mostrar solo los albumes cuyo artista contenga "Metallica"
            Console.WriteLine(">> 2.1.c - Albumes cuyo artista contiene 'Metallica':");
            Console.WriteLine("-------------------------------------------");
            foreach (Album a in albumes)
            {
                if (a.getArtista().Contains("Metallica"))
                {
                    Console.WriteLine(a.ToString());
                }
            }
            Console.WriteLine();

            // ========================================================
            // EJERCICIO 2.2 - Fecha de registro
            // ========================================================
            Console.WriteLine(">> 2.2 - Fecha actual de registro:");
            Console.WriteLine("-------------------------------------------");
            DateTime ahora = DateTime.Now;
            Console.WriteLine("Fecha: " + ahora.ToShortDateString());
            Console.WriteLine();

            // ========================================================
            // EJERCICIO 2.3 - Guardar en fichero
            // ========================================================
            Console.WriteLine(">> 2.3 - Guardando albumes en fichero...");
            Console.WriteLine("-------------------------------------------");
            string ruta = "albumes.txt";
            GuardarAlbums(albumes, ruta);
            Console.WriteLine("Albumes guardados en: " + Path.GetFullPath(ruta));
            Console.WriteLine();

            Console.WriteLine("===========================================");
            Console.WriteLine("Pulsa una tecla para salir...");
            Console.ReadKey();
        }

        // ============================================================
        // EJERCICIO 2.3 - Método GuardarAlbums
        // ============================================================
        // Guarda todos los álbumes en un fichero de texto, uno por línea,
        // con los campos separados por ;
        //
        // Formato de cada línea:
        //   titulo;artista;anyo;disponible
        // Ejemplo:
        //   Master of Puppets;Metallica;1986;True
        // ============================================================
        public static void GuardarAlbums(List<Album> lista, string ruta)
        {
            StreamWriter sw = File.CreateText(ruta);

            foreach (Album a in lista)
            {
                string linea = a.getTitulo() + ";" +
                               a.getArtista() + ";" +
                               a.getAnyo() + ";" +
                               a.isDisponible();
                sw.WriteLine(linea);
            }

            sw.Close();
        }
    }
}
