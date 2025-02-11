
using AutoMapper;
using Core.Responses;
using ToDoListSite.DataAccess.Abstracts;
using ToDoListSite.Models.Dtos.Categories.Requests;
using ToDoListSite.Models.Dtos.Categories.Responses;
using ToDoListSite.Models.Entities;
using ToDoListSite.Service.Abstratcts;
using ToDoListSite.Service.Rules;

namespace ToDoListSite.Service.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _businessRules;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper ,CategoryBusinessRules rules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _businessRules = rules;
    }




    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest create, string userId)
    {
        Category createdCategory = _mapper.Map<Category>(create);

        // iş kuralı
        _categoryRepository.Add(createdCategory);

        CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(createdCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Category Eklendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        List<Category> categorys = _categoryRepository.GetAll();
        List<CategoryResponseDto> responses = _mapper.Map<List<CategoryResponseDto>>(categorys);


        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };

    }

    public ReturnModel<CategoryResponseDto?> GetById(int id)
    {
        var category = _categoryRepository.GetById(id);
        _businessRules.CategoryIsNullCheck(category);

        var response = _mapper.Map<CategoryResponseDto>(category);

        return new ReturnModel<CategoryResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> Remove(int id)
    {
        Category category = _categoryRepository.GetById(id);


        Category deletedCategory = _categoryRepository.Remove(category);

        CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(deletedCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Category Silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategory)
    {
        Category category = _categoryRepository.GetById(updateCategory.Id);

        Category update = new Category
        {
            Id = category.Id,
            ToDos = updateCategory.ToDos,
            Name = updateCategory.Name,
            CreatedDate = category.CreatedDate,
        };

        Category updatedCategory = _categoryRepository.Update(update);

        CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(updatedCategory);
        return new ReturnModel<CategoryResponseDto>
        {
            Data = dto,
            Message = "Category güncellendi",
            StatusCode = 200,
            Success = true
        };
    }
}
