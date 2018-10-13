using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace werewolves
{
    public class AtNight
    {
        public class AWerewolf
        {
            private readonly Moderator _moderator = new Moderator();

            [Fact]
            public void NobodyDiesTonight()
            {
                Assert.Equal("it is now daytime", _moderator.LastMessage());
            }

            [Fact]
            public void CanKillFred()
            {
                _moderator.SendOrder(new OrderInfo("target Fred"));
                Assert.Equal("Fred has died", _moderator.LastMessage());
            }

            [Fact]
            public void CanKillSue()
            {
                _moderator.RegisterPlayer("Wilf");
                _moderator.SendOrder(new OrderInfo("target Sue"));
                Assert.Equal("Sue has died", _moderator.LastMessage());
            }
        }

        public class AVillager
        {
            private readonly Moderator _moderator = new Moderator();

            [Fact]
            public void CantKillSue()
            {
                _moderator.RegisterPlayer("Dave");
                _moderator.SendOrder(new OrderInfo("Dave", "target Sue"));
                Assert.Equal("it is now daytime", _moderator.LastMessage());
            }
        }
    }
}
