

using Core.Responses;
using ToDoListSite.Models.Dtos.Tokens.Responses;
using ToDoListSite.Models.Dtos.Users.Requests;
using ToDoListSite.Service.Abstratcts;

namespace ToDoListSite.Service.Concretes;

public class AuthenticationService(IUserService _userService, IJwtService _jwtService) : IAuthenticationService
{


    public async Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto)
    {
        var user = await _userService.LoginAsync(dto);
        var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponseDto>
        {
            Data = tokenResponse,
            Message = "Giriş Başarılı",
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto)
    {
        var user = await _userService.RegisterAsync(dto);
        var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponseDto>
        {
            Data = tokenResponse,
            Message = "Kayıt işlemi Başarılı",
            StatusCode = 200,
            Success = true
        };
    }
}