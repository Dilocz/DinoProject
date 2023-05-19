using System;
using Microsoft.EntityFrameworkCore;
using Context = DinoProject.Context;

namespace DinoProject.Models.Repositories
{
    public class DinoRepository : IDinoRepository
    {
        private Context.AppContext _dbContext;
        public DinoRepository(Context.AppContext dbContext)
		{
            _dbContext = dbContext;
		}

        public List<Dino> FindAll()
        {
            return _dbContext.Dinos.Include(m => m.When).ToList();
        }

        public Dino? FindById(int id)
        {
            return _dbContext.Dinos.Where(m => m.Id == id).FirstOrDefault();
        }
        public bool AddDina(string name, string photoPath, string description, When when)
        {
            _dbContext.Dinos.Add(new Dino()
            {
                When = when,
                Name = name,
                Description = description,
                Photo = photoPath
            });

            if (_dbContext.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }
        public bool Del(Dino dino)
        {
            _dbContext.Remove(dino);
            _dbContext.SaveChanges();

            return true;
        }
        public bool Edit(Dino dino)
        {
            _dbContext.Update(dino);
            _dbContext.SaveChanges();

            return true;
        }
    }
}