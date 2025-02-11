using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoListSite.Models.Dtos.ToDos.Requests;
using ToDoListSite.Service.Abstratcts;

namespace ToDoListSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDosController(IToDoService _todoService) : ControllerBase
{

    [HttpGet("getall")]
    [Authorize(Roles = "User,Admin")]
    public IActionResult GetAll()
    {
        var result = _todoService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    [Authorize(Roles = "User,Admin")]
    public IActionResult Add([FromBody] CreateToDoRequest dto)
    {
        var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _todoService.Add(dto, userId);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    [Authorize(Roles = "User,Admin")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _todoService.GetById(id);
        return Ok(result);
    }

    [HttpDelete("delete")]
    [Authorize(Roles = "User,Admin")]
    public IActionResult Delete([FromQuery] Guid id)
    {

        var result = _todoService.Remove(id);
        return Ok(result);
    }

    [HttpPut("update")]
    [Authorize(Roles = "User,Admin")]
    public IActionResult Update([FromBody] UpdateToDoRequest dto)
    {
        var result = _todoService.Update(dto);
        return Ok(result);
    }
    [HttpGet("gettodobyclue")]
    [Authorize(Roles = "User,Admin")]
    public IActionResult GetToDoByNameClue([FromBody]string name)
    {
        var result = _todoService.GetToDoByNameClue(name);
        return Ok(result);
    }
    [HttpGet("gettodobyimportance")]
    [Authorize(Roles = "User,Admin")]
    public IActionResult GetToDoByImportance()
    {
        var result = _todoService.GetToDoByImportance();
        return Ok(result);
    }


}