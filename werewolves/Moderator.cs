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

        private readonly List<(string, TheSeer.Seer)> _resolutions = new List<(string, TheSeer.Seer)>();
        private PlayerList _playerList = new PlayerList();

        public void EndNight()
        {
            _resolutions.ForEach(x => x.Item2.Whisper(x.Item1));
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

        private bool SenderIsWerewolf(string orderInfoSender)
        {
            return string.IsNullOrEmpty(orderInfoSender);
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
            _playerList.Register(dave, "Villager");
        }

        public void Send(string player, BloodLetter seer)
        {
        }
    }

    class PlayerList
    {
        public void Register(string name, string villager)
        {
            
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