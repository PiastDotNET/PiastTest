using PiastTest.DTOs;
using PiastTest.Models;

namespace PiastTest.Converters
{
    public class MatchConverter : IConverter<Match, MatchDTO>
    {
        private IConverter<Team, TeamDTO> _teamConverter;
        public MatchConverter(IConverter<Team, TeamDTO> teamConverter)
        {
            _teamConverter = teamConverter;
        }
        public Match Convert(MatchDTO dto)
        {
            return new Match()
            {
                Hosts = _teamConverter.Convert(dto.Hosts),
                Guests = _teamConverter.Convert(dto.Guests)
            };
        }

        public MatchDTO Convert(Match model)
        {
            return new MatchDTO()
            {
                Hosts = _teamConverter.Convert(model.Hosts),
                Guests = _teamConverter.Convert(model.Guests)
            };
        }
    }
}