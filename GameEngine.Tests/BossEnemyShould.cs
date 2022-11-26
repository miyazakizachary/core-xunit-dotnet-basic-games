using Xunit;
using GameEngine;

namespace GameEngine.Tests
{
    [Trait("Class", "BossEnemy")]
    public class BossEnemyShould
    {
        private readonly BossEnemy sut;
        public BossEnemyShould()
        {
            sut = new BossEnemy();
        }
        [Fact]
        [Trait("Category", "Enemy")]
        public void HaveCorrectPower()
        {
            // Assert.Equal(166.666, sut.TotalSpecialAttackPower);
            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3); // rounding, just make sure actual us changed
        }
    }
}