using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListSite.Models.Dtos.Tokens.Responses;
using ToDoListSite.Models.Dtos.Users.Requests;

namespace ToDoListSite.Service.Abstratcts;

public interface IAuthenticationService
{
    Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto);
    Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto);
}

