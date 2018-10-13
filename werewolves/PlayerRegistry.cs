using System.Collections.Generic;

namespace werewolves
{
    class PlayerRegistry
    {
        private readonly Dictionary<string, Player> _players = new Dictionary<string, Player>();

        public void Register(string name, string role)
        {
            _players.Add(name, new Player(name, role));
        }

        public Player GetPlayer(string playerName)
        {
            return null;
        }
    }
}