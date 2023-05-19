using System;
namespace DinoProject.Models
{
	public class Dino
	{
		public int Id { get; set; }
		public When When { get; set; }
		public string Photo { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
