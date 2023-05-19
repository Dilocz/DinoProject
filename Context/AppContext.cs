using System;
using DinoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DinoProject.Context
{
    public class AppContext : DbContext
    {
        public DbSet<Dino> Dinos { get; set; }
        public DbSet<When> When { get; set; }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
    }

}