using Mastermind.Application;
using Mastermind.Application.Interfaces;
using Mastermind.Domain.Entities;
using Mastermind.Domain.Interfaces.Services;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Application
{
    public class GuessAppService : AppServiceBase<Guess>, IGuessAppService
    {
        public GuessAppService(IDbContextScopeFactory dbContextFactory, IGuessService service) : base(dbContextFactory, service) { }
    }
}
