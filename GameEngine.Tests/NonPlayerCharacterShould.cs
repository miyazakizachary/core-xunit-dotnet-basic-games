using System;
using Xunit;
using Xunit.Abstractions;

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
        // MemberData("property name", MemberType = typeof(class name))
        [MemberData("TestDataYield", MemberType = typeof(TestDamageHealthData))]
        public void TakeDamage(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }

        // the following technique, we could get compiler checking rather than runtime checking
        [Theory]
        // MemberData("property name", MemberType = typeof(class name))
        [MemberData(nameof(TestDamageHealthData.TestDataYield), MemberType = typeof(TestDamageHealthData))]
        public void TakeDamage2(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }

        // external data bridging from class
         [Theory]
        // MemberData("property name", MemberType = typeof(class name))
        [MemberData(nameof(TestDamageHealthExternalData.TestData), MemberType = typeof(TestDamageHealthExternalData))]
        public void TakeDamageExternal(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }

        // using custom data attributes
        [Theory]
        [TestDamageHealthAttributeData]
        public void TakeDamageAttribute(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }

        // using custom data attributes with external file
        [Theory]
        [TestDamageHealthFileAttribute]
        public void TakeDamageAttributeExternalFile(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }


        public void Dispose()
        {
            
        }
    }
}