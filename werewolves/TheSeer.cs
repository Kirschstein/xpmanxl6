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


        [Fact]
        public void BloodLetterCanMarkPlayerAsWolfPack()
        {
            var moderator = new Moderator();
            moderator.NewPlayer("vince", "villager");

            var bloodLetter = new BloodLetter(moderator);
            var seer = new Seer(moderator);

            seer.TargetPlayer("vince");
            bloodLetter.TargetPlayer("vince");

            moderator.EndNight();
            Assert.Equal("werewolf", seer.PlayerAlignment);
        }

        [Fact]
        public void BloodLetterMarksASpecificPlayerAsWolfPack()
        {
            var moderator = new Moderator();
            moderator.NewPlayer("vince", "villager");
            moderator.NewPlayer("joe", "villager");

            var bloodLetter = new BloodLetter(moderator);
            var seer = new Seer(moderator);

            seer.TargetPlayer("joe");
            bloodLetter.TargetPlayer("vince");

            moderator.EndNight();
            Assert.Equal("villager", seer.PlayerAlignment);
        }

        public interface ICanBeWhisperedTo
        {
            void Whisper(string alignment);
        }

        public class Seer : ICanBeWhisperedTo
        {
            private readonly Moderator _moderator;
            public string PlayerAlignment { get; private set;  }
            public string TargettedPlayer { get; private set; }

            public Seer(Moderator moderator)
            {
                _moderator = moderator;
            }

            public void TargetPlayer(string player)
            {
                _moderator.Send(player, this);
                TargettedPlayer = player;
            }

            public void Whisper(string alignment)
            {
                PlayerAlignment = alignment;
            }
        }     
        
    }

    public class BloodLetter
    {
        private readonly Moderator _moderator;

        public BloodLetter(Moderator moderator)
        {
            _moderator = moderator;
        }

        public void TargetPlayer(string player)
        {
            _moderator.Send(player, this);
        }
    }
}
