

using Core.Repositories;
using ToDoListSite.DataAccess.Abstracts;
using ToDoListSite.DataAccess.Contexts;
using ToDoListSite.Models.Entities;

namespace ToDoListSite.DataAccess.Concretes;

public class EfCategoryRepository : EfRepositoryBase<BaseDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}
