using System.Collections.Generic;

namespace werewolves
{
    class PlayerList
    {
        private Dictionary<string, Player> _players = new Dictionary<string, Player>();

        public void Register(string name, string role)
        {
            _players.Add(name, new Player(name, role));
        }
    }
}