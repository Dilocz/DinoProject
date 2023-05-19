using System;

namespace DinoProject.Models.Repositories
{
	public interface IWhenRepository
	{
		List<When> FindAll();
		When? FindById(int id);
	}
}
