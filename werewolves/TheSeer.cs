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

        public class Moderator
        {
            private readonly string _role;

            public Moderator(string role)
            {
                _role = role;
            }

            public string Send(string david)
            {
                return _role;
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
