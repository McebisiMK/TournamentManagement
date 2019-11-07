using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TournamentManagement.Entities.Models;

namespace TournamentManagement.IRepository_Tournament
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournament>> GetAll();
        Task<Tournament> GetById(int id);
        Task<Tournament> GetByName(string name);
        Task<IEnumerable<Tournament>> GetByLocation(string location);
        Task<IEnumerable<Tournament>> GetByDate(DateTime startDate);
        Task Save(Tournament tournament);
        Task Update(Tournament oldTournament, Tournament newTournament);
        Task Delete(Tournament tournament);
        bool Exist(int id);
    }
}
