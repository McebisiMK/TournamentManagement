using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentManagement.Entities.Models;
using TournamentManagement.IRepository_Registration;
using TournamentManagement.IRepository_Team;
using TournamentManagement.IRepository_Tournament;
using TournamentManagement.IServices_Registration;

namespace TournamentManagement.Services_Registration
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;

        public RegistrationService(ITournamentRepository tournamentRepository, ITeamRepository teamRepository, IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
            _tournamentRepository = tournamentRepository;
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Registration>> GetAll()
        {
            return await _registrationRepository.GetAll();
        }

        public async Task<Registration> GetById(int id)
        {
            return await _registrationRepository.GetById(id);
        }

        public async Task<IEnumerable<RegisteredTeam>> GetRegisteredTeams(int tournamentId)
        {
            return await _registrationRepository.GetRegisteredTeams(tournamentId);
        }

        public async Task Register(Registration registration)
        {
            if (IsValid(registration))
            {
                var existingTournament = _tournamentRepository.Exist(tournament => tournament.Id.Equals(registration.TournamentId));
                var existingTeam = _teamRepository.Exist(team => team.Id.Equals(registration.TeamId));
                var existingRegistration = _registrationRepository.Exist(reg => reg.TournamentId.Equals(registration.TournamentId) &&
                                                                                reg.TeamId.Equals(registration.TeamId));

                if (existingTournament && existingTeam && !existingRegistration)
                {
                    await _registrationRepository.Register(registration);
                }
            }
        }

        public async Task Update(int id, Registration newRegistration)
        {
            if (IsValid(newRegistration))
            {
                var existingRegistration = _registrationRepository.Exist(registration => registration.Id.Equals(id));

                if (existingRegistration)
                {
                    var oldRegistration = await _registrationRepository.GetById(id);
                    await _registrationRepository.Update(oldRegistration, newRegistration);
                }
            }
        }

        public async Task Delete(int id)
        {
            var existingRegistration = _registrationRepository.Exist(registration => registration.Id.Equals(id));

            if (existingRegistration)
            {
                var registration = await _registrationRepository.GetById(id);
                await _registrationRepository.Delete(registration);
            }
        }

        private bool IsValid(Registration registration)
        {
            return (Valid(registration.TournamentId) && 
                    Valid(registration.TeamId) && 
                    Valid(registration.Amount)
                    );
        }

        private bool Valid(decimal input)
        {
            return (input > 0);
        }
    }
}