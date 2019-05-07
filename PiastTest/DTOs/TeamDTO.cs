using System.Collections.Generic;

namespace PiastTest.DTOs
{
    public class TeamDTO
    {
        public IEnumerable<PlayerDTO> Players { get; set; }
        public int Score { get; set; }   
    }
}