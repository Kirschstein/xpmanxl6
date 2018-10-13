using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace werewolves
{
    public class NobodyDiesTonightSpec
    {
        private readonly Moderator _moderator = new Moderator();

        [Fact]
        public void NobodyDiesTonight()
        {
            Assert.Equal("it is now daytime", _moderator.LastMessage());
        }

        [Fact]
        public void WerewolfKillsFred()
        {
            _moderator.SendOrder(new OrderInfo("target Fred"));
            Assert.Equal("Fred has died", _moderator.LastMessage());
        }

        [Fact]
        public void WerewolfKillsSue()
        {
            _moderator.SendOrder(new OrderInfo("target Sue"));
            Assert.Equal("Sue has died", _moderator.LastMessage());
        }

        [Fact]
        public void VillagerDoesntKillSue()
        {
            Assert.Equal("it is now daytime", _moderator.LastMessage());
        }
    }
}
