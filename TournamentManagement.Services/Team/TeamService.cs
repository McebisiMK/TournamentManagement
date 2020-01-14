using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentManagement.Entities.Models;
using TournamentManagement.IRepository_Team;
using TournamentManagement.IServices_Team;

namespace TournamentManagement.Services_Team
{
    public class TeamService : ITeamService
    {
        private ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _teamRepository.GetAll();
        }

        public async Task<Team> GetById(int id)
        {
            return await _teamRepository.GetById(id);
        }

        public async Task<Team> GetByName(string name)
        {
            return await _teamRepository.GetByName(name);
        }

        public async Task<IEnumerable<Team>> GetByCaptain(string captain)
        {
            return await _teamRepository.GetByCaptain(captain);
        }

        public async Task<IEnumerable<Team>> GetByCoach(string coach)
        {
            return await _teamRepository.GetByCoach(coach);
        }

        public async Task Save(Team newTeam)
        {
            if (IsValid(newTeam))
            {
                var existingTeam = _teamRepository.Exist(team => team.Name.Equals(newTeam.Name));

                if (!existingTeam)
                {
                    await _teamRepository.Save(newTeam);
                }
            }
        }

        public async Task Update(int id, Team newTeam)
        {
            if (IsValid(newTeam))
            {
                var existingTeam = _teamRepository.Exist(team => team.Id.Equals(id));

                if (existingTeam)
                {
                    var oldTeam = await _teamRepository.GetById(id);
                    await _teamRepository.Update(oldTeam, newTeam);
                }
            }
        }

        public async Task Delete(int id)
        {
            var existingTeam = _teamRepository.Exist(team => team.Id.Equals(id));

            if (existingTeam)
            {
                var team = await _teamRepository.GetById(id);
                await _teamRepository.Delete(team);
            }
        }

        private bool IsValid(Team team)
        {
            return 
                (
                    !Invalid(team.Name) && 
                    !Invalid(team.Captain) && 
                    !Invalid(team.Coach)
                );
        }

        private bool Invalid(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }
    }
}