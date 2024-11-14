using AppRecetas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRecetas.Data
{
    public class TodoItemBaseDatos
    {
        SQLiteAsyncConnection BaseDatos;
        public TodoItemBaseDatos()
        {
        }
        async Task Init()
        {
            // Si la base de datos existe termina el metodo Init()
            if (BaseDatos is not null)
            {
                return;
            }
            // inicializamos la base de datos
            // y creamos la tabla Recetas basada en el modelo Recetas.cs
            BaseDatos = new SQLiteAsyncConnection(Constantes.RutaBaseDeDatos, Constantes.Banderas);
            var resultado = await BaseDatos.CreateTableAsync<Recetas>();
        }

        // Obtener todos los registros de la tabla Recetas:
        public async Task<List<Recetas>> GetRecetasAsync()
        {
            await Init();
            return await BaseDatos.Table<Recetas>().ToListAsync();
        }
        // Obtener una sola receta por su ID:
        public async Task<Recetas> GetRecetaAsync(int id)
        {
            await Init();
            return await BaseDatos.Table<Recetas>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        // Guardar o actualiza una receta:
        public async Task<int> SaveRecetaAsync(Recetas receta)
        {
            await Init();
            if (receta.Id != 0)
            {
                return await BaseDatos.UpdateAsync(receta);
            }
            else
            {
                return await BaseDatos.InsertAsync(receta);
            }
        }
        // Elimina una receta
        public async Task<int> DeleteRecetaAsync(Recetas receta)
        {
            await Init();
            return await BaseDatos.DeleteAsync(receta);
        }
    }
}
