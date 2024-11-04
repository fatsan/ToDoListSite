﻿using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListSite.Models.Dtos.Categories.Requests;
using ToDoListSite.Models.Dtos.Categories.Responses;
using ToDoListSite.Models.Dtos.ToDos.Requests;
using ToDoListSite.Models.Dtos.ToDos.Responses;

namespace ToDoListSite.Service.Abstratcts;

public interface ICategoryService
{
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto?> GetById(int id);
    ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest create); // string userId gelebilir içine

    ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategory);

    ReturnModel<CategoryResponseDto> Remove(int id);


};