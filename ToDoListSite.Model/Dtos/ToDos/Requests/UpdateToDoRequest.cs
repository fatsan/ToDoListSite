

using ToDoListSite.Models.Entities;

namespace ToDoListSite.Models.Dtos.ToDos.Requests;

public sealed record UpdateToDoRequest(
    Guid Id,
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,

    Priority Priority,
    int CategoryId,
    bool Completed,
    Category Category,
    string UserId,
    User User
    );