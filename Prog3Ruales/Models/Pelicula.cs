using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Prog3Ruales.Models
{

    class Pelicula
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int AnioEstreno { get; set; }
        public int Calificacion { get; set; }

    }
}
