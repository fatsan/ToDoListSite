

using AutoMapper;
using Core.Responses;
using Microsoft.Extensions.Hosting;
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

    //public ReturnModel<ToDoResponseDto> Add(CreateToDoRequest create)
    //{
    //    throw new NotImplementedException();
    //}

    public ReturnModel<ToDoResponseDto> Add(CreateToDoRequest create) //, Guid userId)
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
