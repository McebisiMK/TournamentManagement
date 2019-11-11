using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentManagement.Entities.Models;

namespace TournamentManagement.IServices_Team
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetById(int id);
        Task<Team> GetByName(string name);
        Task<IEnumerable<Team>> GetByCaptain(string captain);
        Task<IEnumerable<Team>> GetByCoach(string coach);
        Task Save(Team team);
        Task Update(int id, Team team);
        Task Delete(int id);
    }
}
