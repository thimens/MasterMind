using Mastermind.Domain.Entities;
using Mastermind.Domain.Interfaces.Repositories;
using Mastermind.Domain.Interfaces.Services;

namespace Mastermind.Domain.Services
{
    public class PlayerService : ServiceBase<Player>, IPlayerService
    {
        public PlayerService(IRepositoryBase<Player> repository) : base(repository) { }
    }
}
