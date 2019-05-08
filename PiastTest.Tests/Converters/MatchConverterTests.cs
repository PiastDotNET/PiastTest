using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PiastTest.Converters;
using PiastTest.DTOs;
using PiastTest.Models;

namespace PiastTest.Tests.Converters
{
    [TestFixture]
    public class MatchConverterTests
    {
        [Test]
        public void ConvertsDTOToModel_WithValidHost()
        {
            //arrange
            //act
            var result = _sut.Convert(_matchDTO);

            //assert
            result.Hosts.Should().Be(_teamConverterHostsModelResult);
        }

        [Test]
        public void ConvertsDTOToModel_WithValidGuest()
        {
            //arrange
            //act
            var result = _sut.Convert(_matchDTO);

            //assert
            result.Guests.Should().Be(_teamConverterGuestsModelResult);
        }

        [Test]
        public void ConvertsModelToDTO_WithValidHost()
        {
            //arrange
            //act
            var result = _sut.Convert(_matchModel);

            //assert
            result.Hosts.Should().Be(_teamConverterHostsDtoResult);
        }

        [Test]
        public void ConvertsModelToDTO_WithValidGuest()
        {
            //arrange
            //act
            var result = _sut.Convert(_matchModel);

            //assert
            result.Guests.Should().Be(_teamConverterGuestsDtoResult);
        }

        [SetUp]
        public void SetUp()
        {
            _matchModel = new Models.Match()
            {
                Hosts = new Team(),
                Guests = new Team()
            };

            _matchDTO = new MatchDTO()
            {
                Hosts = new TeamDTO(),
                Guests = new TeamDTO()
            };

            _teamConverterGuestsDtoResult = new TeamDTO();
            _teamConverterHostsDtoResult = new TeamDTO();
            _teamConverterGuestsModelResult = new Team();
            _teamConverterHostsModelResult = new Team();

            _teamConverter = new Mock<IConverter<Team, TeamDTO>>();
            _teamConverter.Setup(x=>x.Convert(_matchModel.Guests)).Returns(_teamConverterGuestsDtoResult);
            _teamConverter.Setup(x=>x.Convert(_matchModel.Hosts)).Returns(_teamConverterHostsDtoResult);
            _teamConverter.Setup(x=>x.Convert(_matchDTO.Guests)).Returns(_teamConverterGuestsModelResult);
            _teamConverter.Setup(x=>x.Convert(_matchDTO.Hosts)).Returns(_teamConverterHostsModelResult);

            _sut = new MatchConverter(_teamConverter.Object);
        }

        private IConverter<Models.Match, MatchDTO> _sut;
        private Mock<IConverter<Team, TeamDTO>> _teamConverter;
        private Models.Match _matchModel;
        private MatchDTO _matchDTO;
        private Team _teamConverterHostsModelResult;
        private TeamDTO _teamConverterHostsDtoResult;
        private Team _teamConverterGuestsModelResult;
        private TeamDTO _teamConverterGuestsDtoResult;
    }
}