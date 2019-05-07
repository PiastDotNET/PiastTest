
using PiastTest.DTOs;
using PiastTest.Models;

namespace PiastTest.Services
{
    public interface IMatchService
    {
        Match CreateMatch(int guestId, int hostId);
        Team ShowWinner(Match match);
        MatchDTO ShwoMatch(Match match);
    }
}