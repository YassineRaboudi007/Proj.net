using Gestion_note.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_note.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes{ get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Matiere> Matieres{ get; set; }
        public DbSet<Filier> Filiers { get; set; }
}
}
