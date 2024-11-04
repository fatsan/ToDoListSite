
using Microsoft.EntityFrameworkCore;
using ToDoListSite.Models.Entities;

namespace ToDoListSite.DataAccess.Contexts;
public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opt) : base(opt)
    {

    }

    public DbSet<ToDo> Todos { get; set; }
    public DbSet<Category> Categories { get; set; }
}
