using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentManagement.Entities.Models;
using TournamentManagement.IRepository;
using TournamentManagement.IRepository_Team;

namespace TournamentManagement.Repositories_Team
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IGenericRepository<Team> _genericRepository;

        public TeamRepository(IGenericRepository<Team> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _genericRepository.GetAll().ToListAsync();
        }

        public async Task<Team> GetById(int id)
        {
            return await _genericRepository
                            .GetBy(team => team.Id.Equals(id))
                            .SingleOrDefaultAsync();
        }

        public async Task<Team> GetByName(string name)
        {
            return await _genericRepository
                            .GetBy(team => team.Name.Equals(name))
                            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Team>> GetByCaptain(string captain)
        {
            return await _genericRepository
                            .GetBy(team => team.Captain.Equals(captain))
                            .ToListAsync();
        }

        public async Task<IEnumerable<Team>> GetByCoach(string coach)
        {
            return await _genericRepository
                            .GetBy(team => team.Coach.Equals(coach))
                            .ToListAsync();
        }

        public async Task Save(Team team)
        {
            await _genericRepository.Add(team);

            await _genericRepository.SaveAsync();
        }

        public async Task Update(Team oldTeam, Team newTeam)
        {
            _genericRepository.Update(oldTeam, newTeam);

            await _genericRepository.SaveAsync();
        }

        public async Task Delete(Team team)
        {
            _genericRepository.Delete(team);

            await _genericRepository.SaveAsync();
        }

        public bool Exist(int id)
        {
            return _genericRepository.Exist(team => team.Id.Equals(id));
        }
    }
}
