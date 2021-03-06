using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentManagement.Entities.Models;
using TournamentManagement.IServices_Registration;

namespace TournamentManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet("getby/tournament/{tournamentId}")]
        public async Task<IEnumerable<RegisteredTeam>> GetByTournament(int tournamentId)
        {
            return await _registrationService.GetRegisteredTeams(tournamentId);
        }

        [HttpPost("save")]
        public async Task Save([FromBody] Registration registration)
        {
            await _registrationService.Register(registration);
        }

        [HttpPut("update/{id}")]
        public async Task Update(int id, [FromBody] Registration registration)
        {
            await _registrationService.Update(id, registration);
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete(int id)
        {
            await _registrationService.Delete(id);
        }
    }
}