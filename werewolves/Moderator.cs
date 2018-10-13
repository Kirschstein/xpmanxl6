using System.Collections.Generic;

namespace werewolves
{
    public class Moderator
    {
        private readonly Dictionary<string, string> _players
            = new Dictionary<string, string>();

        public string Send(string david)
        {
            return _players[david];
        }

        public void NewPlayer(string player, string role)
        {
            _players.Add(player, role);
        }
    }
}