using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mastermind.Domain.Entities;
using Mastermind.Models;

namespace Mastermind.AutoMapper
{
    public class DomainToModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Guess, GuessResultModel>().IgnoreAllNonExisting();

            CreateMap<Player, PlayerResultModel>()
                .ForMember(d => d.GuessHistory, opt => opt.MapFrom(s => s.Guesses))
                .IgnoreAllNonExisting();

            CreateMap<Game, GameResultModel>()
                .ForMember(d => d.GameId, opt => opt.MapFrom(s => s.Id.ToString()))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status == 0 ? "Waiting players" : s.Status == 1 ? "Playing" : "Solved"))
                .ForMember(d => d.Players, opt => opt.MapFrom(s => s.Players))
                .ForMember(d => d.Round, opt => opt.MapFrom(s => s.Guesses.Where(g => g.PlayerId == s.PlayerId).Count() + 1))
                .IgnoreAllNonExisting();
        }
    }
}