
using AutoMapper;
using Microsoft.Extensions.Hosting;
using ToDoListSite.Models.Dtos.Categories.Requests;
using ToDoListSite.Models.Dtos.Categories.Responses;
using ToDoListSite.Models.Dtos.ToDos.Requests;
using ToDoListSite.Models.Dtos.ToDos.Responses;
using ToDoListSite.Models.Entities;

namespace ToDoListSite.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateToDoRequest, ToDo>();
        CreateMap<UpdateToDoRequest, ToDo>();
        CreateMap<ToDo, ToDoResponseDto>()
            .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
            .ForMember(x => x.User, opt => opt.MapFrom(X => X.User.UserName));

        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();
        CreateMap<Category, CategoryResponseDto>();
    }
}
