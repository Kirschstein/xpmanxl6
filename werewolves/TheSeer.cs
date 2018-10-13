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
            Moderator moderator = new Moderator("villager");
            var seer = new Seer(moderator);
            var result = seer.TargetPlayer("david");

            Assert.Equal("villager", result);
        }

        [Fact]
        public void CanCheckAPlayerDiscoverWerewolf()
        {
            Moderator moderator = new Moderator("werewolf");
            moderator.NewPlayer("david", "werewolf");
            var seer = new Seer(moderator);
            var result = seer.TargetPlayer("david");

            Assert.Equal("werewolf", result);
        }

        public class Moderator
        {
            private readonly string _role;
            private Dictionary<string, string> _players = new Dictionary<string, string>();

            public Moderator(string role)
            {
                _role = role;
            }

            public string Send(string david)
            {
                return _role;
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

            public string TargetPlayer(string david)
            {
                return _moderator.Send(david);
            }
        }

      
    }
}
