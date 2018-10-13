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

            seer.TargetPlayer("david");

            moderator.EndNight();
            Assert.Equal("villager", seer.PlayerAlignment);
        }

        [Fact]
        public void CanCheckAPlayerDiscoverAlignedToWarewolves()
        {
            var moderator = new Moderator();
            moderator.NewPlayer("david", "werewolf");
            var seer = new Seer(moderator);
            seer.TargetPlayer("david");
            
            moderator.EndNight();
            Assert.Equal("werewolf", seer.PlayerAlignment);
        }

        [Fact]
        public void MultiplePlayersCanBeDistinguished()
        {
            var moderator = new Moderator();

            moderator.NewPlayer("david", "werewolf");
            moderator.NewPlayer("vince", "villager");

            var seer = new Seer(moderator);
            seer.TargetPlayer("david");
            moderator.EndNight();
            Assert.Equal("werewolf", seer.PlayerAlignment);
        }

        public class Seer
        {
            private readonly Moderator _moderator;
            public string PlayerAlignment { get; private set;  }

            public Seer(Moderator moderator)
            {
                _moderator = moderator;
            }

            public void TargetPlayer(string player)
            {
                _moderator.Send(player, this);
            }

            public void Whisper(string alignment)
            {
                PlayerAlignment = alignment;
            }
        }      
    }
}
