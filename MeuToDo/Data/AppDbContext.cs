using MeuToDo.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuToDo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public DbSet<ToDo> ToDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
}
