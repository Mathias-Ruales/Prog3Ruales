using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog3Ruales.Models;
using SQLite;
namespace Prog3Ruales
{
    class PeliculaRepo
    {
        string _dbPath;
        public string StatusMessage { get; set; }

        private SQLiteAsyncConnection conn;

        private async Task Init()
        {
            if (conn != null)
                return;
                conn = new SQLiteAsyncConnection(_dbPath);
                await conn.CreateTableAsync<Pelicula>();
        }

        public PeliculaRepo(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewPelicula(String Titulo, String Genero, int AnioEstreno, int Calificacion)
        {
            try
            {
                await Init();
                if (AnioEstreno < 2023 && Calificacion < 3)
                    throw new Exception("Año de estreno debe ser mayor o igual a 2023 y calificación debe ser mayor o igual a 3.");

                int rowsAdded = await conn.InsertAsync(new Pelicula
                {
                    Titulo = Titulo,
                    Genero = Genero,
                    AnioEstreno = AnioEstreno,
                    Calificacion = Calificacion
                });
                StatusMessage = $"{rowsAdded} fila(s) insertada(s).";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error al insertar: {ex.Message}";

            }
        }
                                                                                                                                          
        public async Task<List<Pelicula>> GetPeliculaAsync()
        {
            await Init();
            return await conn.Table<Pelicula>().ToListAsync();
        }                                                   

    }
}
