using System;

namespace DinoProject.Models.Repositories
{
	public interface IDinoRepository
	{
		List<Dino> FindAll();
		Dino? FindById(int id);
        bool AddDina(string name, string photoPath, string description, When when);
		bool Del(Dino dino);
		public bool Edit(Dino dino);
    }
}