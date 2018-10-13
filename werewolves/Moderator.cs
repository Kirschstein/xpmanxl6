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

        public void Send(string order, IReceiveAMessage receiver)
        {
            receiver.Receive(Send(order));
        }

        public string Send(string order)
        {
            var parts = order.Split(" ");
            var targetName = parts.Last();

            return _players[targetName];
        }

        internal void SendOrder(OrderInfo orderInfo)
        {
            SendOrder(orderInfo.Order);
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

    public class OrderInfo
    {

        public OrderInfo(string order)
        {
            this.Order = order;
        }

        public string Order { get; }
    }
}