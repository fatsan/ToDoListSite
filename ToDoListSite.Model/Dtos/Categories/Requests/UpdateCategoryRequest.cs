
using ToDoListSite.Models.Entities;

namespace ToDoListSite.Models.Dtos.Categories.Requests;

public sealed record UpdateCategoryRequest(
    int Id,
    string Name,
    List<ToDo> ToDos
    );

