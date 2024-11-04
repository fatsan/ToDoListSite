
using ToDoListSite.Models.Entities;

namespace ToDoListSite.Models.Dtos.Categories.Requests;

public sealed record CreateCategoryRequest(
    string Name,
    List<ToDo> ToDos
    );

