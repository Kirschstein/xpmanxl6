using System.Collections.Generic;
using System.Linq;

namespace werewolves
{
    public class Moderator
    {
        private string _message = "it is now daytime";

        private readonly Dictionary<string, string> _players
            = new Dictionary<string, string>();

        public string Send(string order)
        {
            var parts = order.Split(" ");
            var targetName = parts.Last();

            return _players[targetName];
        }

        public void NewPlayer(string player, string role)
        {
            _players.Add(player, role);
        }

        public void SendOrder(string order)
        {
            var parts = order.Split(" ");
            var targetName = parts.Last();

            _message = $"{targetName} has died";
        }

        public string LastMessage()
        {
            return _message;
        }


    }

    public interface IReceiveAMessage
    {

    }
}