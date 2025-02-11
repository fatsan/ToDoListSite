

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoListSite.DataAccess.Abstracts;
using ToDoListSite.DataAccess.Concretes;
using ToDoListSite.DataAccess.Contexts;

namespace ToDoListSite.DataAccess;

public static class DataAccessRepositoryDependencies
{
    public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITodoRepository, EfToDoRepository>();

        services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        return services;
    }
}
