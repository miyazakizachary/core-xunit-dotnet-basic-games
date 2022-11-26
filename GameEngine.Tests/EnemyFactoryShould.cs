
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

using GameEngine;

namespace GameEngine.Tests
{
    [Trait("Class", "EnemyFactory")]
    public class EnemyFactoryShould: IDisposable
    {
        private readonly EnemyFactory sut;
        private readonly ITestOutputHelper _output;
        public EnemyFactoryShould(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Creating New PlayerCharacter");
            sut = new EnemyFactory();
        }


        [Fact(Skip="TEST SKIPPING")]
        [Trait("Category", "Types")]
        public void CreateNormalEnemyByDefault()
        {
            
            var enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        [Trait("Category", "Types")]
        public void CreateNormalEnemyByDefaul_NotTypeBossEnemy()
        {
            _output.WriteLine("Creating Normal Enemy");

            
            var enemy = sut.Create("Zomba");

            Assert.IsNotType<BossEnemy>(enemy);
        }

        [Fact]
        [Trait("Category", "Types")]
        public void CreateBossEnemy()
        {
            _output.WriteLine("Creating Boss Enemy");
            
            var bossEnemy = sut.Create("Zombie King", true);

            BossEnemy boss = Assert.IsType<BossEnemy>(bossEnemy); // get cast result
            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        [Trait("Category", "Generic")]
        public void CreateBossEnemy_GenericTypeValid()
        {
            
            var bossEnemy = sut.Create("Zombie King", true);

            // assert parent type
            Assert.IsAssignableFrom<Enemy>(bossEnemy);
        }

        [Fact]
        [Trait("Category", "Object Instances")]
        public void CreateSeparateInstances()
        {
            

            var enemy1 = sut.Create("Dracule");
            var enemy2 = sut.Create("Dracule");

            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        [Trait("Category", "Object Instances")]
        public void InstancesCanHaveSimilarReferences()
        {
            

            var enemy1 = sut.Create("Dracula");
            var enemy2 = enemy1;

            Assert.Same(enemy1, enemy2);

        }

        [Fact]
        [Trait("Category", "Object Instances")]
        public void NotAllowNullName()
        {
            
            
            // Assert.Throws<ArgumentNullException>(() => sut.Create(null));
            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }

        [Fact]
        [Trait("Category", "Throw Exceptions")]
        public void OnlyAllowKingOrQueenBossEnemyName()
        {
            

            var ex = Assert.Throws<EnemyCreationException>( () => sut.Create("Zombie", true) );
            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }

        public void Dispose()
        {
            _output.WriteLine($"Disposing Enemy Factory {sut.ToString()}");
        }
    }
}