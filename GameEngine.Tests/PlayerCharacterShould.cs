using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests {
    [Trait("Class", "PlayerCharacter")]
    public class PlayerCharacterShould: IDisposable {

        private readonly PlayerCharacter sut;
        private readonly ITestOutputHelper _output;
        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;
            sut = new PlayerCharacter();
        }
        [Fact]
        public void BeInexperiencedWhenNew() {
            PlayerCharacter sut = new PlayerCharacter();
            Assert.True(sut.IsNoob);
        }
        [Fact]
        public void CalculateFullName()
        {
            // Given
            

            // When
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            var expected = "Sarah Smith";

            // Then
            Assert.Equal(expected, sut.FullName);
            Assert.Equal("SARAH SMITH", sut.FullName, ignoreCase: true);
            Assert.StartsWith("Sarah", sut.FullName);
            Assert.Contains("ah Sm", sut.FullName);
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName); //ensure each starting character is capital
        }

        [Fact]
        public void StartWithDefaultHeatlh()
        {
            
            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void HealthDefaultNotEqualToZero()
        {
            
            Assert.NotEqual(0, sut.Health);
        }

        [Fact]
        public void HealthIncreaseInRange()
        {
           
           sut.Sleep(); // expect increase of health between 1 to 100]

            // Assert.True(sut.Health >= 101 && sut.Health <= 200);
            // Assert.InRange<int>(sut.Health, 101, 200); 
            Assert.InRange(sut.Health, 101, 200); // integer is inferred
        }

        [Fact]
        public void NicknameHaveNullByDefault()
        {
            
            Assert.Null(sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            
            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void NotHavePistol()
        {
            
            Assert.DoesNotContain("Pistol", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            
            // predicate function (lambda) will result in true/false
            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword")); 
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            
            var expectedWeapons = new string[] { "Long Bow", "Short Bow", "Short Sword"};

            Assert.Equal(expectedWeapons, sut.Weapons);
        }

        [Fact]
        public async Task HaveNoEmptyDefaultWeapons()
        {
            
            await System.Threading.Tasks.Task.CompletedTask;
            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
           

           Assert.Raises<EventArgs>(
            handler => sut.PlayerSlept += handler,
            handler => sut.PlayerSlept -= handler,
            () => sut.Sleep()
           );
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            

            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }

        public void Dispose()
        {
            _output.WriteLine($"Disposing Player Character {sut.FullName}");
        }
    }
}