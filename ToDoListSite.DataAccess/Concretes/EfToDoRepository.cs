

using Core.Repositories;
using ToDoListSite.DataAccess.Abstracts;
using ToDoListSite.DataAccess.Contexts;
using ToDoListSite.Models.Entities;

namespace ToDoListSite.DataAccess.Concretes;

public class EfToDoRepository : EfRepositoryBase<BaseDbContext, ToDo, Guid>, ITodoRepository
{
    public EfToDoRepository(BaseDbContext context) : base(context)
    {
    }
}
