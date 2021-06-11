using Microsoft.Extensions.DependencyInjection;
using Web.Services.Repositories.Abstract;
using Web.Services.Repositories.Implementation;

namespace Web.Services.Repositories
{
    public static class RepositoryRegister
    {
        public static void Init(IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommunityRepository, CommunityRepository>();
        }
    }
}