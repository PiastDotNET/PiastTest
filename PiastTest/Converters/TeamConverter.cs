using System.Linq;
using PiastTest.DTOs;
using PiastTest.Models;

namespace PiastTest.Converters
{
    public class TeamConverter : IConverter<Team, TeamDTO>
    {
        private IConverter<Player, PlayerDTO> _playerConverter;
        public TeamConverter(IConverter<Player, PlayerDTO> playerConverter)
        {
            _playerConverter = playerConverter;
        }
        public Team Convert(TeamDTO dto)
        {
            var result =  new Team()
            {
                Score = dto.Score,
                Players = dto.Players.Select(x=>_playerConverter.Convert(x))
            };

            return result;
        }

        public TeamDTO Convert(Team model)
        {
            var result =  new TeamDTO()
            {
                Score = 0, //TODO Poprawic
                Players = model.Players.Select(x=>_playerConverter.Convert(x))
            };

            return result;
        }
    }
}