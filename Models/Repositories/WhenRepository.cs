using System;
using Microsoft.EntityFrameworkCore;
using Context = DinoProject.Context;

namespace DinoProject.Models.Repositories
{
	public class WhenRepository : IWhenRepository
    {
        private Context.AppContext _dbContext;

		public WhenRepository(Context.AppContext dbContext)
		{
            _dbContext = dbContext;
		}

        public List<When> FindAll()
        {
            return _dbContext.When.ToList();
        }

        public When? FindById(int id)
        {
            return _dbContext.When.Where(g => g.Id == id).FirstOrDefault();
        }
    }
}

