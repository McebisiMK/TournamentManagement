using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentManagement.Entities.Models;

namespace TournamentManagement.IServices_Registration
{
    public interface IRegistrationService
    {
        Task<IEnumerable<RegisteredTeam>> GetRegisteredTeams(int tournamentId);
        Task Register(Registration registration);
        Task Update(int id, Registration registration);
        Task Delete(int id);
    }
}