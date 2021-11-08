using DSCC_CW1_MicroservicesAPI_8466.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_API_8466.Repository
{
    public interface IGenreRepository
    {
        void InsertGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(int genreId);
        Genre GetGenreById(int id);
        IEnumerable<Genre> GetGenres();
    }
}
