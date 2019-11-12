using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentManagement.Entities.Models;
using TournamentManagement.IRepository_Tournament;
using TournamentManagement.IServices_Tournament;

namespace TournamentManagement.Services_Tournament
{
    public class TournamentService : ITournamentService
    {
        private ITournamentRepository _tournamentRepository;

        public TournamentService(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<IEnumerable<Tournament>> GetAll()
        {
            return await _tournamentRepository.GetAll();
        }

        public async Task<Tournament> GetById(int id)
        {
            return await _tournamentRepository.GetById(id);
        }

        public async Task<Tournament> GetByName(string name)
        {
            return await _tournamentRepository.GetByName(name);
        }

        public async Task<IEnumerable<Tournament>> GetByLocation(string location)
        {
            return await _tournamentRepository.GetByLocation(location);
        }

        public async Task<IEnumerable<Tournament>> GetByDate(DateTime startDate)
        {
            return await _tournamentRepository.GetByDate(startDate);
        }

        public async Task Save(Tournament newTournament)
        {
            if (IsValid(newTournament))
            {
                var existingTournament = _tournamentRepository.Exist(tournament => tournament.Name.Equals(newTournament.Name));

                if (!existingTournament)
                {
                    await _tournamentRepository.Save(newTournament);
                }
            }
        }

        public async Task Update(int id, Tournament newTournament)
        {
            if (IsValid(newTournament))
            {
                var existingTournament = _tournamentRepository.Exist(tournament => tournament.Id.Equals(id));

                if (existingTournament)
                {
                    var oldTournament = await _tournamentRepository.GetById(id);
                    await _tournamentRepository.Update(oldTournament, newTournament);
                }
            }
        }

        public async Task Delete(int id)
        {
            var existingTournament = _tournamentRepository.Exist(tournament => tournament.Id.Equals(id));

            if (existingTournament)
            {
                var tournament = await _tournamentRepository.GetById(id);
                await _tournamentRepository.Delete(tournament);
            }
        }

        private bool IsValid(Tournament tournament)
        {
            return (!Invalid(tournament.Name) && !Invalid(tournament.Location) && tournament.StartDate >= DateTime.Today);
        }

        private bool Invalid(string input)
        {
            return (string.IsNullOrWhiteSpace(input));
        }
    }
}