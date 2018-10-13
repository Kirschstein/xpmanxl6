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
            var seer = new Seer();
            var result = seer.TargetPlayer();

            Assert.Equal("villager", result);
        }

        public class Seer
        {
            public string TargetPlayer()
            {
                return "villager";
            }
        }
    }
}
