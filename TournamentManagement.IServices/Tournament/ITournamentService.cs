using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TournamentManagement.Entities.Models;

namespace TournamentManagement.IServices_Tournament
{
    public interface ITournamentService
    {
        Task<IEnumerable<Tournament>> GetAll();
        Task<Tournament> GetById(int id);
        Task<Tournament> GetByName(string name);
        Task<IEnumerable<Tournament>> GetByLocation(string location);
        Task<IEnumerable<Tournament>> GetByDate(DateTime startDate);
        Task Save(Tournament tournament);
        Task Update(int id, Tournament tournament);
        Task Delete(int id);
    }
}
