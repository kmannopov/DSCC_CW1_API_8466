using DSCC_CW1_MicroservicesAPI_8466.DbContexts;
using DSCC_CW1_MicroservicesAPI_8466.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_API_8466.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookContext _dbContext;

        public GenreRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteGenre(int genreId)
        {
            var genre = _dbContext.Genres.Find(genreId);
            _dbContext.Genres.Remove(genre);
            Save();
        }

        public Genre GetGenreById(int id)
        {
            var book = _dbContext.Genres.Find(id);
            return book;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _dbContext.Genres.ToList();
        }

        public void InsertGenre(Genre genre)
        {
            _dbContext.Add(genre);
            Save();
        }

        public void UpdateGenre(Genre genre)
        {
            _dbContext.Entry(genre).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
