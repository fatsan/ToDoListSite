

using Core.Repositories;
using ToDoListSite.Models.Entities;

namespace ToDoListSite.DataAccess.Abstracts;

public interface ITodoRepository : IRepository<ToDo, Guid>
{
}
