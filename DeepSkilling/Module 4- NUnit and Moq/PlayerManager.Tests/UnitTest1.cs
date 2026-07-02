using System;
using Moq;
using NUnit.Framework;
using PlayersManagerLib;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        private Mock<IPlayerMapper> mockPlayerMapper;

        [OneTimeSetUp]
        public void Init()
        {
            mockPlayerMapper = new Mock<IPlayerMapper>();

            mockPlayerMapper
                .Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>()))
                .Returns(false);

            mockPlayerMapper
                .Setup(x => x.AddNewPlayerIntoDb(It.IsAny<string>()));
        }

        [TestCase]
        public void RegisterNewPlayer_ShouldCreatePlayer()
        {
            Player player = Player.RegisterNewPlayer("Virat", mockPlayerMapper.Object);

            Assert.That(player, Is.Not.Null);
            Assert.That(player.Name, Is.EqualTo("Virat"));
            Assert.That(player.Age, Is.EqualTo(23));
            Assert.That(player.Country, Is.EqualTo("India"));
            Assert.That(player.NoOfMatches, Is.EqualTo(30));
        }

        [TestCase]
        public void RegisterNewPlayer_WithEmptyName_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Player.RegisterNewPlayer("", mockPlayerMapper.Object);
            });
        }
    }
}