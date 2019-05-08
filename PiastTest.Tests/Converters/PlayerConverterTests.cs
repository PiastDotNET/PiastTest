using FluentAssertions;
using NUnit.Framework;
using PiastTest.Converters;
using PiastTest.DTOs;
using PiastTest.Models;

namespace PiastTest.Tests.Converters
{
    [TestFixture]
    public class PlayerConverterTests
    {
        [Test]
        public void ConvertsModelToDTO_WithValidNumber()
        {
            //arrange
            //act
            var result = _sut.Convert(_playerModel);

            //assert
            result.Number.Should().Be(_playerModel.Number);
        }

        [Test]
        public void ConvertsModelToDTO_WithValidName()
        {
            //arrange
            //act
            var result = _sut.Convert(_playerModel);

            //assert
            result.Name.Should().Be(_playerModel.Name);
        }

        [Test]
        public void ConvertsModelToDTO_WithValidSurname()
        {
            //arrange
            //act
            var result = _sut.Convert(_playerModel);

            //assert
            result.Surname.Should().Be(_playerModel.Surname);
        }

        [Test]
        public void ConvertsDTOToModel_WithValidNumber()
        {
            //arrange
            //act
            var result = _sut.Convert(_playerDTO);

            //assert
            result.Number.Should().Be(_playerDTO.Number);
        }

        [Test]
        public void ConvertsDTOToModel_WithValidName()
        {
            //arrange
            //act
            var result = _sut.Convert(_playerDTO);

            //assert
            result.Name.Should().Be(_playerDTO.Name);
        }

        [Test]
        public void ConvertsDTOToModel_WithValidSurname()
        {
            //arrange
            //act
            var result = _sut.Convert(_playerDTO);

            //assert
            result.Surname.Should().Be(_playerDTO.Surname);
        }

        [SetUp]
        public void SetUp()
        {
            _playerDTO = new PlayerDTO
            {
                Name = "DtoName",
                Surname = "DtoSurname",
                Number = 5
            };

            _playerModel = new Player
            {
                Name = "ModelName",
                Surname = "ModelSurname",
                Number = 8
            };

            _sut = new PlayerConverter();
        }
        private IConverter<Player, PlayerDTO> _sut;
        private Player _playerModel;
        private PlayerDTO _playerDTO;
    }
}