using System;
using Xunit;
using Xunit.Abstractions;
using GameEngine;

namespace GameEngine.Tests
{
    public class NonPlayerCharacterShould : IDisposable
    {

        private readonly PlayerCharacter sut;
        private readonly ITestOutputHelper _output;
        public NonPlayerCharacterShould(ITestOutputHelper output)
        {
            sut = new PlayerCharacter();
            _output = output;
        }


        [Theory]
        [InlineData(0, 100)]
        [InlineData(1, 99)]
        [InlineData(50, 50)]
        [InlineData(101, 1)] // always gives 1
        public void TakeDamage(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}