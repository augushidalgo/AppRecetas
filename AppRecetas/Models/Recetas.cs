using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRecetas.Models
{
    public class Recetas
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Id_categoria { get; set; }
        public int Tiempo_preparacion { get; set; }
        public string Dificultad {  get; set; }
        public int Porciones {  get; set; }
        public DateTime Fecha_creacion { get; set; }

    }
}
