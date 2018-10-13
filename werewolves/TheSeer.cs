using System;
using System.Collections.Generic;
using Xunit;

namespace werewolves
{
    public class TheSeer
    {
        [Fact]
        public void CanCheckAPlayerAndDiscoverTheyAreNotAWerewolf()
        {
            var moderator = new Moderator();
            moderator.NewPlayer("david", "villager");
            var seer = new Seer(moderator);
            var result = seer.TargetPlayer("david");

            Assert.Equal("villager", result);
        }

        [Fact]
        public void CanCheckAPlayerDiscoverWerewolf()
        {
            var moderator = new Moderator();
            moderator.NewPlayer("david", "werewolf");
            var seer = new Seer(moderator);
            var result = seer.TargetPlayer("david");

            Assert.Equal("werewolf", result);
        }

        public class Moderator
        {
            private readonly Dictionary<string, string> _players
                = new Dictionary<string, string>();

            public string Send(string david)
            {
                return _players[david];
            }

            public void NewPlayer(string player, string role)
            {
                _players.Add(player, role);
            }
        }

        public class Seer
        {
            private readonly Moderator _moderator;

            public Seer(Moderator moderator)
            {
                _moderator = moderator;
            }

            public string TargetPlayer(string player)
            {
                return _moderator.Send(player);
            }
        }

      
    }
}
