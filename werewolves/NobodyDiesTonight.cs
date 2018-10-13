using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace werewolves
{
    public class NobodyDiesTonightSpec
    {
        private string _message = "it is now daytime";

        [Fact]
        public void NobodyDiesTonight()
        {
            Assert.Equal("it is now daytime", LastMessage());
        }

        [Fact]
        public void FredDies()
        {
            SendOrder("target Fred");
            Assert.Equal("Fred has died", LastMessage());
        }

        [Fact]
        public void SueDies()
        {
            SendOrder("target Fred");
            Assert.Equal("Fred has died", LastMessage());
        }

        private void SendOrder(string targetFred)
        {
            if (targetFred == "target Fred")
            {
                _message = "Fred has died";
            }
            else
            {
                _message = "Sue has died";
            }
        }

        private string LastMessage()
        {
            return _message;
        }
    }
}
