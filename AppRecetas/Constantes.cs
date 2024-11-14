using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRecetas
{
    public static class Constantes
    {
        // Constante para el nombre de la base de datos
        public const string NombreBaseDeDatos = "RecestasSQLite.db3";

        public const SQLite.SQLiteOpenFlags Banderas =
            // Abre la base de datos en modo lectura/escritura
            SQLite.SQLiteOpenFlags.ReadWrite |
            // Crea la base de datos si no existe
            SQLite.SQLiteOpenFlags.Create |
            // Habilitar el acceso a bases de datos multiproceso 
            SQLite.SQLiteOpenFlags.SharedCache;
        // Definimos una constante para la ruta de la base de datos:
        public static string RutaBaseDeDatos =>
            Path.Combine(FileSystem.AppDataDirectory, NombreBaseDeDatos);
    }
}
