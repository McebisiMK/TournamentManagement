using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TournamentManagement.Entities.Models;
using TournamentManagement.IRepository;
using TournamentManagement.IRepository_Tournament;

namespace TournamentManagement.Repositories_Tournament
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly IGenericRepository<Tournament> _genericRepository;

        public TournamentRepository(IGenericRepository<Tournament> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Tournament>> GetAll()
        {
            return await _genericRepository.GetAll().ToListAsync();
        }

        public async Task<Tournament> GetById(int id)
        {
            return await _genericRepository
                            .GetBy(Tournament => Tournament.Id.Equals(id))
                            .SingleOrDefaultAsync();
        }

        public async Task<Tournament> GetByName(string name)
        {
            return await _genericRepository
                            .GetBy(tournament => tournament.Name.Equals(name))
                            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Tournament>> GetByLocation(string location)
        {
            return await _genericRepository
                            .GetBy(Tournament => Tournament.Location
                            .Equals(location)).ToListAsync();
        }

        public async Task<IEnumerable<Tournament>> GetByDate(DateTime startDate)
        {
            return await _genericRepository
                            .GetBy(tournament => tournament.StartDate == startDate)
                            .ToListAsync();
        }

        public async Task Save(Tournament tournament)
        {
            await _genericRepository.Add(tournament);

            await _genericRepository.SaveAsync();
        }

        public async Task Update(Tournament oldTournament, Tournament newTournament)
        {
            _genericRepository.Update(oldTournament, newTournament);

            await _genericRepository.SaveAsync();
        }

        public async Task Delete(Tournament tournament)
        {
            _genericRepository.Delete(tournament);

            await _genericRepository.SaveAsync();
        }

        public bool Exist(int id)
        {
            return _genericRepository.Exist(tournament => tournament.Id.Equals(id));
        }
    }
}
