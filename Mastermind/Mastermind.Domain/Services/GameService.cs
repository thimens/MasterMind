using Mastermind.Domain.Entities;
using Mastermind.Domain.Interfaces.Repositories;
using Mastermind.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Domain.Services
{
    public class GameService : ServiceBase<Game>, IGameService
    {
        public GameService(IRepositoryBase<Game> repository) : base(repository) { }
    }
}
