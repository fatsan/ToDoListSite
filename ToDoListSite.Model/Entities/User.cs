

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace ToDoListSite.Models.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }
    public List<ToDo> ToDos { get; set; }

}
