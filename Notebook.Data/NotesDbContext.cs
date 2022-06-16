using Microsoft.EntityFrameworkCore;
using Notebook.Core;

namespace Notebook.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {
        }

        public DbSet<Note<int>> Notes { get; set; }
    }
}