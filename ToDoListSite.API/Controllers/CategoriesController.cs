using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoListSite.Models.Dtos.Categories.Requests;
using ToDoListSite.Service.Abstratcts;

namespace ToDoListSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService _categoryService) : ControllerBase
{

    [HttpGet("getall")]

    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateCategoryRequest dto)
    {
        var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _categoryService.Add(dto, userId);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]

    public IActionResult GetById([FromRoute] int id)
    {
        var result = _categoryService.GetById(id);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery] int id)
    {

        var result = _categoryService.Remove(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateCategoryRequest dto)
    {
        var result = _categoryService.Update(dto);
        return Ok(result);
    }

 

}