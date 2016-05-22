using AutoMapper;
using System.Linq;
using Mastermind.Domain.Entities;
using Mastermind.Models;
using System;

namespace Mastermind.AutoMapper
{
    public class DomainToModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Guess, GuessResultModel>().IgnoreAllNonExisting();

            CreateMap<Player, PlayerResultModel>()
                .ForMember(d => d.GuessHistory, opt => opt.MapFrom(s => s.Id == s.Game.PlayerId || s.Game.Status == 2 ? s.Guesses : null))
                .IgnoreAllNonExisting();

            CreateMap<Game, GameResultModel>()
                .ForMember(d => d.GameId, opt => opt.MapFrom(s => s.Id.ToString()))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status == 0 ? "Waiting players" : s.Status == 1 ? "Playing" : "Solved"))
                .ForMember(d => d.Players, opt => opt.MapFrom(s => s.Players))
                .ForMember(d => d.Round, opt => opt.MapFrom(s => s.PlayerId == default(Guid) ? 1 : s.Players.First(p => p.Id == s.PlayerId).Guesses.Count() + 1))
                .ForMember(d => d.Guess, opt => opt.MapFrom(s => s.PlayerId == default(Guid) ? null : s.Players.First(p => p.Id == s.PlayerId).Guesses.OrderByDescending(g => g.Id).FirstOrDefault()))
                .IgnoreAllNonExisting();
        }
    }
}