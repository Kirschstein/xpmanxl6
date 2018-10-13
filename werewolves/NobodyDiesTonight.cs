using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace werewolves
{
    public class NobodyDiesTonightSpec
    {
        private string _message = "it is now daytime";
        private Moderator _moderator = new Moderator();

        [Fact]
        public void NobodyDiesTonight()
        {
            Assert.Equal("it is now daytime", LastMessage());
        }

        [Fact]
        public void WerewolfTargetsFred()
        {
            SendOrder("target Fred");
            Assert.Equal("Fred has died", LastMessage());
        }

        [Fact]
        public void SueDies()
        {
            SendOrder("target Sue");
            Assert.Equal("Sue has died", LastMessage());
        }

        public void SendOrder(string order)
        {
            _moderator.SendOrder(order);
        }

        private string LastMessage()
        {
            return _moderator.LastMessage();
        }
    }
}
