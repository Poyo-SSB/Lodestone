using NUnit.Framework;

namespace Lodestone.Tests.Structures.World
{
    [TestFixture]
    public class LevelTest
    {
        private Lodestone.Structures.Level.Level Level;

        [SetUp]
        public void LoadLevel() => this.Level = new Lodestone.Structures.Level.Level("./resources/TestWorld");

        [Test]
        public void GameRulesTest()
        {
            Assert.AreEqual(true, this.Level.GameRules.AnnounceAdvancements);
            Assert.AreEqual(true, this.Level.GameRules.CommandBlockOutput);
            Assert.AreEqual(true, this.Level.GameRules.DisableElytraMovementCheck);
            Assert.AreEqual(true, this.Level.GameRules.DisableRaids);
            Assert.AreEqual(false, this.Level.GameRules.DoDaylightCycle);
            Assert.AreEqual(false, this.Level.GameRules.DoEntityDrops);
            Assert.AreEqual(false, this.Level.GameRules.DoFireTick);
            Assert.AreEqual(true, this.Level.GameRules.DoImmediateRespawn);
            Assert.AreEqual(false, this.Level.GameRules.DoInsomnia);
            Assert.AreEqual(false, this.Level.GameRules.DoLimitedCrafting);
            Assert.AreEqual(false, this.Level.GameRules.DoMobLoot);
            Assert.AreEqual(false, this.Level.GameRules.DoMobSpawning);
            Assert.AreEqual(false, this.Level.GameRules.DoPatrolSpawning);
            Assert.AreEqual(false, this.Level.GameRules.DoTileDrops);
            Assert.AreEqual(false, this.Level.GameRules.DoTraderSpawning);
            Assert.AreEqual(false, this.Level.GameRules.DoWeatherCycle);
            Assert.AreEqual(false, this.Level.GameRules.DrowningDamage);
            Assert.AreEqual(false, this.Level.GameRules.FallDamage);
            Assert.AreEqual(false, this.Level.GameRules.FireDamage);
            Assert.AreEqual(true, this.Level.GameRules.ForgiveDeadPlayers);
            Assert.AreEqual(true, this.Level.GameRules.KeepInventory);
            Assert.AreEqual(true, this.Level.GameRules.LogAdminCommands);
            Assert.AreEqual(65536, this.Level.GameRules.MaxCommandChainLength);
            Assert.AreEqual(0, this.Level.GameRules.MaxEntityCramming);
            Assert.AreEqual(false, this.Level.GameRules.MobGriefing);
            Assert.AreEqual(true, this.Level.GameRules.NaturalRegeneration);
            Assert.AreEqual(0, this.Level.GameRules.RandomTickSpeed);
            Assert.AreEqual(false, this.Level.GameRules.ReducedDebugInfo);
            Assert.AreEqual(true, this.Level.GameRules.SendCommandFeedback);
            Assert.AreEqual(true, this.Level.GameRules.ShowDeathMessages);
            Assert.AreEqual(0, this.Level.GameRules.SpawnRadius);
            Assert.AreEqual(false, this.Level.GameRules.SpectatorsGenerateChunks);
            Assert.AreEqual(false, this.Level.GameRules.UniversalAnger);
        }
    }
}
