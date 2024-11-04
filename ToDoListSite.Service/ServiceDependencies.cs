
using Microsoft.Extensions.DependencyInjection;
using ToDoListSite.Service.Abstratcts;
using ToDoListSite.Service.Concretes;
using ToDoListSite.Service.Profiles;
using ToDoListSite.Service.Rules;

namespace ToDoListSite.Service;
public static class ServiceDependencies
{

    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfiles));
        
        services.AddScoped<ToDoBusinessRules>();
        services.AddScoped<CategoryBusinessRules>();
        
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        
        services.AddScoped<IUserService, UserService>();
        
        services.AddScoped<IToDoService, ToDoService>();
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}
