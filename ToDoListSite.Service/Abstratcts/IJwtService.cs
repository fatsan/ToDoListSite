using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListSite.Models.Dtos.Tokens.Responses;
using ToDoListSite.Models.Entities;

namespace ToDoListSite.Service.Abstratcts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateJwtTokenAsync(User user);
}
