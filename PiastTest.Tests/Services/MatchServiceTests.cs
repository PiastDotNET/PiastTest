using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PiastTest.Converters;
using PiastTest.DTOs;
using PiastTest.Models;
using PiastTest.Repositories;
using PiastTest.Services;

namespace PiastTest.Tests.Services
{
    [TestFixture]
    public class MatchServiceTests
    {
        [Test]
        public void ConvertsMatch_WithConverter()
        {
            //arrange
            //act
            var result = _sut.ShwoMatch(_match);

            //assert
            result.Should().Be(_convertedMatch);
        }

        [Test]
        public void CreatesMatch_WithTeamsFromDatabase()
        {
            //arrange
            //act
            var result = _sut.CreateMatch(4,6);

            //assert
            result.Hosts.Should().Be(_hostsTeam);
            result.Guests.Should().Be(_guestsTeam);
            _teamRepository.VerifyAll();
        }

        [Test]
        public void Throws_WhenGuestsScoreIsLessThanZero([Range(-100,-1)]int score)
        {
            //arrange
            _guestsTeam.Score = score;

            //act
            //assert
            Assert.That(
                () => _sut.ShowWinner(_match), 
                Throws.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("Guests Score cannot be less than 0"));
        }

        [Test]
        public void Throws_WhenHostsScoreIsLessThanZero([Range(-100,-1)]int score)
        {
            //arrange
            _hostsTeam.Score = score;

            //act
            //assert
            Assert.That(
                () => _sut.ShowWinner(_match), 
                Throws.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("Hosts Score cannot be less than 0"));
        }

        [Test]
        public void RetursNull_WhenMatchIsDraw()
        {
            //arrange
            //act
            var result = _sut.ShowWinner(_match);

            //assert
            result.Should().BeNull();
        }

        [Test]
        public void ReturnsGuests_WhenTheyWin()
        {
            //arrange=
            _guestsTeam.Score = 1;

            //act
            var result = _sut.ShowWinner(_match);

            //assert
            result.Should().Be(_match.Guests);
        }

        [Test]
        public void ReturnsHosts_WhenTheyWin()
        {
            //arrange
            _hostsTeam.Score = 1;

            //act
            var result = _sut.ShowWinner(_match);

            //assert
            result.Should().Be(_match.Hosts);
        }

        [SetUp]
        public void SetUp()
        {
            _hostsTeam = new Team();
            _guestsTeam = new Team();

            _match = new Models.Match()
            {
                Hosts = _hostsTeam,
                Guests = _guestsTeam
            };

            _teamRepository = new Mock<ITeamRepository>();
            _matchConverter = new Mock<IConverter<Models.Match, MatchDTO>>();

            _teamRepository.Setup(x=>x.GetById(4)).Returns(_guestsTeam).Verifiable();
            _teamRepository.Setup(x=>x.GetById(6)).Returns(_hostsTeam).Verifiable();

            _matchConverter.Setup(x=>x.Convert(_match)).Returns(_convertedMatch);


            _sut = new MatchService(_teamRepository.Object, _matchConverter.Object);
        }
        private IMatchService _sut;
        private Mock<ITeamRepository> _teamRepository;
        private Mock<IConverter<Models.Match, MatchDTO>> _matchConverter;
        private Models.Match _match;
        private MatchDTO _convertedMatch;
        private Team _hostsTeam;
        private Team _guestsTeam;
    }
}