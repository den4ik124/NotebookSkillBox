using Microsoft.EntityFrameworkCore;
using Notebook.Core;

namespace Notebook.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Address>()
            //    .HasIndex(note => note.Index)
            //    .IsUnique();
        }
    }
}