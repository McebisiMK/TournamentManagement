using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TournamentManagement.Entities.Models;
using TournamentManagement.IRepository;
using TournamentManagement.IRepository_Registration;

namespace TournamentManagement.Repositories_Registration
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IGenericRepository<Registration> _genericRepository;
        private readonly TournamentManagementDBContext _dbContext;
        private readonly DbSet<RegisteredTeam> DbSet;

        public RegistrationRepository(IGenericRepository<Registration> genericRepository, TournamentManagementDBContext dbContext)
        {
            _genericRepository = genericRepository;
            _dbContext = dbContext;
            DbSet = dbContext.Set<RegisteredTeam>();
        }

        public async Task<IEnumerable<Registration>> GetAll()
        {
            return await _genericRepository.GetAll().ToListAsync();
        }

        public async Task<Registration> GetById(int id)
        {
            return await _genericRepository
                            .GetBy(registration => registration.Id.Equals(id))
                            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<RegisteredTeam>> GetRegisteredTeams(int tournamentId)
        {
            return await DbSet.FromSqlInterpolated($"EXEC dbo.RegisteredTeams {tournamentId}").ToListAsync();
        }

        public Task Delete(Registration registration)
        {
            throw new System.NotImplementedException();
        }

        public async Task Register(Registration registration)
        {
            await _genericRepository.Add(registration);

            await _genericRepository.SaveAsync();
        }

        public async Task Update(Registration oldRegistration, Registration newRegistration)
        {
            _genericRepository.Update(oldRegistration, newRegistration);

            await _genericRepository.SaveAsync();
        }

        public bool Exist(Expression<Func<Registration, bool>> expression)
        {
            return _genericRepository.Exist(expression);
        }
    }
}