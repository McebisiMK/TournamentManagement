using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TournamentManagement.Entities.Models;

namespace TournamentManagement.IRepository_Team
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetById(int id);
        Task<Team> GetByName(string name);
        Task<IEnumerable<Team>> GetByCaptain(string captain);
        Task<IEnumerable<Team>> GetByCoach(string coach);
        Task Save(Team team);
        Task Update(Team oldTeam, Team newTeam);
        Task Delete(Team team);
        bool Exist(Expression<Func<Team, bool>> expression);
    }
}
