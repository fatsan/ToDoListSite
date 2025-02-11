

using ToDoListSite.Models.Entities;

namespace ToDoListSite.Models.Dtos.ToDos.Responses;

public sealed record ToDoResponseDto(
    string Title, 
    string Description,
    DateTime CreatedTime,
    Priority Priority,
    string Category,
    string User
    );

