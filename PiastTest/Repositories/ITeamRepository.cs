using PiastTest.Models;

namespace PiastTest.Repositories
{
    public interface ITeamRepository
    {
        Team GetById(int id);
    }
}