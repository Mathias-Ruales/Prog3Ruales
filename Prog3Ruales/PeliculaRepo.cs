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

        public async Task AddNewPelicula(String Titulo, String Genero, int AnioEstreno, int Calificacion )
        {
            

        }
                                                                                                                                          
        public async Task<List<Pelicula>> GetPeliculaAsync()
        {
            await Init();
            return await conn.Table<Pelicula>().ToListAsync();
        }                                                   

    }
}
