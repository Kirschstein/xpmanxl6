using System;
using System.Collections.Generic;
using System.Linq;

namespace werewolves
{
    public class Moderator
    {
        private string _message = "it is now daytime";

        private readonly Dictionary<string, string> _players
            = new Dictionary<string, string>();

        private PlayerRegistry _playerRegistry = new PlayerRegistry();

        private List<(string, TheSeer.ICanBeWhisperedTo)> _resolutions = new List<(string, TheSeer.ICanBeWhisperedTo)>();

        public void EndNight()
        {
            _resolutions.ForEach(x => x.Item2.Whisper(x.Item1));
        }

        public void Send(string player, BloodLetter bloodLetter)
        {
            _resolutions = _resolutions.Select(x =>
            {
                if (x.Item2 is TheSeer.Seer seer && player == seer.TargettedPlayer)
                {
                    return ("werewolf", x.Item2);
                }
                return x;
                
            }).ToList();
        }

        public void Send(string player, TheSeer.Seer seer)
        {
            var parts = player.Split(" ");
            var targetName = parts.Last();
            var alignment = _players[targetName];
            _resolutions.Add((alignment, seer));
        }

        internal void SendOrder(OrderInfo orderInfo)
        {
            if (SenderIsWerewolf(orderInfo.Sender))
            {
                var parts = orderInfo.Order.Split(" ");
                var targetName = parts.Last();

                _message = $"{targetName} has died";
            }
        }

        private bool SenderIsWerewolf(string playerName)
        {
            var player = _playerRegistry.GetPlayer(playerName);
            return string.IsNullOrEmpty(playerName);
        }

        public void NewPlayer(string player, string role)
        {
            _players.Add(player, role);
        }

        public string LastMessage()
        {
            return _message;
        }

        public void RegisterPlayer(string dave)
        {
            _playerRegistry.Register(dave, "Villager");
        }
    }

    internal class Player
    {
        public string Name { get; }
        public string Role { get; }

        public Player(string name, string role)
        {
            Name = name;
            Role = role;
        }
    }

    public class OrderInfo
    {
        public string Sender { get; }
        public string Order { get; }

        public OrderInfo(string order)
        {
            Order = order;
        }

        public OrderInfo(string sender, string order) : this(order)
        {
            Sender = sender;
        }
    }
}