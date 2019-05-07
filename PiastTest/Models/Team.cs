using System.Collections.Generic;

namespace PiastTest.Models
{
    public class Team
    {
        public IEnumerable<Player> Players { get; set; }
        public int Score { get; set; }
    }
}