using PiastTest.DTOs;
using PiastTest.Models;

namespace PiastTest.Converters
{
    public class PlayerConverter : IConverter<Player, PlayerDTO>
    {
        public Player Convert(PlayerDTO dto)
        {
            return new Player()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Number = dto.Number
            };
        }

        public PlayerDTO Convert(Player model)
        {
            return new PlayerDTO()
            {
                Name = model.Name,
                Surname = model.Surname,
                Number = model.Number
            };
        }
    }
}