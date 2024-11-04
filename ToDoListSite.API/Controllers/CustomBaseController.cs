using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ToDoListSite.API.Controllers;

public class CustomBaseController : ControllerBase
{

    public string GetUserId()
    {
        return HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
    }


}


