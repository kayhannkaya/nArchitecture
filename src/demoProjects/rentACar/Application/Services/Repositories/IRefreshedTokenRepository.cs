using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface IRefreshedTokenRepository : IAsyncRepository<RefreshToken>, IRepository<RefreshToken>
    {

    }
}
