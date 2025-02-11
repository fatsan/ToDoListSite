

using AutoMapper;
using Azure;
using Core.Responses;

using ToDoListSite.DataAccess.Abstracts;
using ToDoListSite.DataAccess.Concretes;
using ToDoListSite.Models.Dtos.ToDos.Requests;
using ToDoListSite.Models.Dtos.ToDos.Responses;
using ToDoListSite.Models.Entities;
using ToDoListSite.Service.Abstratcts;
using ToDoListSite.Service.Rules;

namespace ToDoListSite.Service.Concretes;

public class ToDoService : IToDoService
{

    private readonly ITodoRepository _toDoRepository;
    private readonly IMapper _mapper;
    private readonly ToDoBusinessRules _businessRules;

    public ToDoService(ITodoRepository toDoRepository, IMapper mapper, ToDoBusinessRules rules)
    {
        _toDoRepository = toDoRepository;
        _mapper = mapper;
        _businessRules = rules;
    }

    public ReturnModel<ToDoResponseDto> Add(CreateToDoRequest create, string userId)
    {
        ToDo createdToDo = _mapper.Map<ToDo>(create);
        createdToDo.Id = Guid.NewGuid();
        //createdToDo.Id = userId;

        _toDoRepository.Add(createdToDo);

        ToDoResponseDto response = _mapper.Map<ToDoResponseDto>(createdToDo);

        return new ReturnModel<ToDoResponseDto>
        {
            Data = response,
            Message = "ToDo Eklendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<ToDoResponseDto>> GetAll()
    {
        List<ToDo> toDos = _toDoRepository.GetAll();
        List<ToDoResponseDto> responses = _mapper.Map<List<ToDoResponseDto>>(toDos);


        return new ReturnModel<List<ToDoResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<ToDoResponseDto>> GetAllByCategoryId(int id)
    {
        var toDos = _toDoRepository.GetAll(x => x.CategoryId == id, false);
        var responses = _mapper.Map<List<ToDoResponseDto>>(toDos);

        return new ReturnModel<List<ToDoResponseDto>>
        {
            Data = responses,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<ToDoResponseDto?> GetById(Guid id)
    {
        var toDo = _toDoRepository.GetById(id);
        _businessRules.ToDoIsNullCheck(toDo);

        var response = _mapper.Map<ToDoResponseDto>(toDo);

        return new ReturnModel<ToDoResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<ToDoResponseDto?>> GetToDoByNameClue(string name)
    {
        var toDos = _toDoRepository.GetAll(x => x.Title.Contains(name) || x.Description.Contains(name), false);
        var responses = _mapper.Map<List<ToDoResponseDto?>>(toDos);

        return new ReturnModel<List<ToDoResponseDto?>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true

        };
    }
    public ReturnModel<List<ToDoResponseDto?>> GetToDoByImportance()
    {
        var toDos1 = _toDoRepository.GetAll(x => x.Priority == Priority.High, false);
        var toDos2 = _toDoRepository.GetAll(x => x.Priority == Priority.Normal, false);
        var toDos3 = _toDoRepository.GetAll(x => x.Priority == Priority.Low, false);
        var AllTodos = new[] { toDos1, toDos2, toDos3 };
        var responses = _mapper.Map<List<ToDoResponseDto?>>(AllTodos);

        return new ReturnModel<List<ToDoResponseDto?>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true

        };
    }

    public ReturnModel<ToDoResponseDto> Remove(Guid id)
    {
        ToDo toDo = _toDoRepository.GetById(id);


        ToDo deletedToDo = _toDoRepository.Remove(toDo);

        ToDoResponseDto response = _mapper.Map<ToDoResponseDto>(deletedToDo);

        return new ReturnModel<ToDoResponseDto>
        {
            Data = response,
            Message = "ToDo Silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<ToDoResponseDto> Update(UpdateToDoRequest updateToDo)
    {
        ToDo toDo = _toDoRepository.GetById(updateToDo.Id);

        ToDo update = new ToDo
        {
            CategoryId = toDo.CategoryId,
            Title = updateToDo.Title,
            Description = updateToDo.Description,
            Priority = updateToDo.Priority,
            UserId = toDo.UserId,
            CreatedDate = toDo.CreatedDate,
            UpdatedDate = toDo.UpdatedDate,
        };

        ToDo updatedToDo = _toDoRepository.Update(update);

        ToDoResponseDto dto = _mapper.Map<ToDoResponseDto>(updatedToDo);
        return new ReturnModel<ToDoResponseDto>
        {
            Data = dto,
            Message = "ToDo güncellendi",
            StatusCode = 200,
            Success = true
        };
    }


}
