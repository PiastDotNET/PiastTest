using System;
using PiastTest.Converters;
using PiastTest.DTOs;
using PiastTest.Models;
using PiastTest.Repositories;

namespace PiastTest.Services
{
    public class MatchService : IMatchService
    {
        private ITeamRepository _teamRepository;
        private IConverter<Match, MatchDTO> _matchConverter;
        public MatchService(ITeamRepository teamRepository, IConverter<Match, MatchDTO> matchConverter)
        {
            _teamRepository = teamRepository;
            _matchConverter = matchConverter;
        }
        public Match CreateMatch(int guestId, int hostId)
        {
            return new Match()
            {
                Hosts = _teamRepository.GetById(hostId),
                Guests = _teamRepository.GetById(guestId)
            };
        }

        public Team ShowWinner(Match match)
        {
            if(match.Guests.Score < 0)
                throw new ArgumentException("Guests Score cannot be less than 0");

            if(match.Hosts.Score < 0)
                throw new ArgumentException("Hosts Score cannot be less than 0");
            
            if(match.Guests.Score == match.Hosts.Score)
                return null;

            return match.Guests.Score > match.Hosts.Score ? match.Guests : match.Hosts;
        }

        public MatchDTO ShwoMatch(Match match)
        {
            return _matchConverter.Convert(match);
        }
    }
}