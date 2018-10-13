using Xunit;

namespace werewolves
{
    public class TheSeer
    {
        [Fact]
        public void CanCheckAPlayerAlignedToVillage()
        {
            var moderator = new Moderator();
            moderator.NewPlayer("david", "villager");
            var seer = new Seer(moderator);
            var alignment = seer.TargetPlayer("david");

            Assert.Equal("villager", alignment);
        }

        [Fact]
        public void CanCheckAPlayerDiscoverAlignedToWarewolves()
        {
            var moderator = new Moderator();
            moderator.NewPlayer("david", "werewolf");
            var seer = new Seer(moderator);
            var alignment = seer.TargetPlayer("david");

            Assert.Equal("werewolf", alignment);
        }

        [Fact]
        public void MultiplePlayersCanBeDistinguished()
        {
            var moderator = new Moderator();

            moderator.NewPlayer("david", "werewolf");
            moderator.NewPlayer("vince", "villager");

            var seer = new Seer(moderator);
            var result = seer.TargetPlayer("david");
            moderator.EndNight();
            Assert.Equal("werewolf", result);
        }

        public class Seer
        {
            private readonly Moderator _moderator;
            public string PlayerAlignment { get; private set;  }

            public Seer(Moderator moderator)
            {
                _moderator = moderator;
            }

            public string TargetPlayer(string player)
            {
                _moderator.Send(player, this);
                return _moderator.Send(player);
            }

            public void Whisper(string alignment)
            {
                PlayerAlignment = alignment;
            }
        }      
    }
}
