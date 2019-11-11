using System.Collections.Generic;
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

        public RegistrationRepository(IGenericRepository<Registration> genericRepository)
        {
            _genericRepository = genericRepository;
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

        public bool Exist(int id)
        {
            return _genericRepository.Exist(registration => registration.Id.Equals(id));
        }
    }
}