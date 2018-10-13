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
        public void OnePersonDies()
        {
            SendOrder();
            Assert.Equal("Fred has died", LastMessage());
        }
        
        private void SendOrder()
        {
            _message = "Fred has died";
        }

        private string LastMessage()
        {
            return _message;
        }
    }
}
