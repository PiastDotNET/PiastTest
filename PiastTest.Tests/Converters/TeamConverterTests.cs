using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PiastTest.Converters;
using PiastTest.DTOs;
using PiastTest.Models;

namespace PiastTest.Tests.Converters
{
    [TestFixture]
    public class TeamConverterTests
    {
        [Test]
        public void ConvertsModelToDTO_WithValidScore()
        {
            //arrange
            //act
            var result = _sut.Convert(_teamModel);

            //assert
            result.Score.Should().Be(_teamModel.Score);
        }

        [Test]
        public void ConvertsModelToDTO_WithValidPlayers()
        {
            //arrange
            //act
            var result = _sut.Convert(_teamModel);

            //assert
            result.Players.Count().Should().Be(1);
            result.Players.First().Should().Be(_palyerConverterDTOResult);
        }

        [Test]
        public void ConvertsDTOToModel_WithValidScore()
        {
            //arrange
            //act
            var result = _sut.Convert(_teamDTO);

            //assert
            result.Score.Should().Be(_teamDTO.Score);
        }

        [Test]
        public void ConvertsDTOToModel_WithValidPlayers()
        {
            //arrange
            //act
            var result = _sut.Convert(_teamDTO);

            //assert
            result.Players.Count().Should().Be(1);
            result.Players.First().Should().Be(_playerConverterModelResult);
        }

        [SetUp]
        public void SetUp()
        {
            _teamModel = new Team()
            {
                Score = 2,
                Players = new List<Player>()
                {
                    new Player()
                }
            };

            _teamDTO = new TeamDTO()
            {
                Score = 6,
                Players = new List<PlayerDTO>()
                {
                    new PlayerDTO()
                }
            };

            _playerConverterModelResult = new Player();
            _palyerConverterDTOResult = new PlayerDTO();
            
            _palyerConverter = new Mock<IConverter<Player, PlayerDTO>>();
            _palyerConverter.Setup(x=>x.Convert(_teamModel.Players.First())).Returns(_palyerConverterDTOResult);
            _palyerConverter.Setup(x=>x.Convert(_teamDTO.Players.First())).Returns(_playerConverterModelResult);

            _sut = new TeamConverter(_palyerConverter.Object);
        }

        private IConverter<Team, TeamDTO> _sut;
        private Mock<IConverter<Player, PlayerDTO>> _palyerConverter;
        private Team _teamModel;
        private TeamDTO _teamDTO;
        private Player _playerConverterModelResult;
        private PlayerDTO _palyerConverterDTOResult;
    }
}