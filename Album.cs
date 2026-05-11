using System;

namespace MusicStore
{
    // ============================================================
    // EJERCICIO 1.2 - Implementación de la clase Album
    // ============================================================
    // Implementada según el diagrama UML proporcionado:
    //   - 4 atributos privados (titulo, artista, anyo, disponible)
    //   - Constructor con 4 parámetros (usando this.)
    //   - Métodos get para cada atributo
    //   - Sobrescritura de ToString()
    // ============================================================
    public class Album
    {
        // Atributos privados (- en UML significa privado)
        private string titulo;
        private string artista;
        private int anyo;
        private bool disponible;

        // Constructor con los 4 parámetros (usando this. tal como pide el examen)
        public Album(string titulo, string artista, int anyo, bool disponible)
        {
            this.titulo = titulo;
            this.artista = artista;
            this.anyo = anyo;
            this.disponible = disponible;
        }

        // Métodos get públicos (+ en UML significa público)
        public string getTitulo()
        {
            return titulo;
        }

        public string getArtista()
        {
            return artista;
        }

        public int getAnyo()
        {
            return anyo;
        }

        public bool isDisponible()
        {
            return disponible;
        }

        // Sobrescritura del método ToString() heredado de Object
        // Devuelve: "Titulo - Artista (Anyo)"
        public override string ToString()
        {
            return titulo + " - " + artista + " (" + anyo + ")";
        }
    }
}
