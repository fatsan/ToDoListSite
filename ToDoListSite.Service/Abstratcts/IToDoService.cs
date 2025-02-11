
using Core.Responses;
using ToDoListSite.Models.Dtos.ToDos.Requests;
using ToDoListSite.Models.Dtos.ToDos.Responses;

namespace ToDoListSite.Service.Abstratcts;

public interface IToDoService
{
    ReturnModel<List<ToDoResponseDto>> GetAll();
    ReturnModel<ToDoResponseDto?> GetById(Guid id);
    ReturnModel<ToDoResponseDto> Add(CreateToDoRequest create, string userId); // string gelebilir içine

    ReturnModel<ToDoResponseDto> Update(UpdateToDoRequest updateToDo);

    ReturnModel<ToDoResponseDto> Remove(Guid id);

    ReturnModel<List<ToDoResponseDto>> GetAllByCategoryId(int id);
    
    ReturnModel<List<ToDoResponseDto?>> GetToDoByNameClue(string name);
    ReturnModel<List<ToDoResponseDto?>> GetToDoByImportance();

};
