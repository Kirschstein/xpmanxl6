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

        public string Send(string order)
        {
            var parts = order.Split(" ");
            var targetName = parts.Last();

            return _players[targetName];
        }

        public void Send(string player, TheSeer.Seer seer)
        {
            var alignment = Send(player);
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