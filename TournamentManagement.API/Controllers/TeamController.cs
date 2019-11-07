using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TournamentManagement.Entities.Models;
using TournamentManagement.IServices_Team;

namespace TournamentManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("getall")]
        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _teamService.GetAll();
        }

        [HttpGet("getby/id/{id}")]
        public async Task<Team> GetById(int id)
        {
            return await _teamService.GetById(id);
        }

        [HttpGet("getby/name/{name}")]
        public async Task<Team> GetByName(string name)
        {
            return await _teamService.GetByName(name);
        }

        [HttpGet("getby/coach/{coach}")]
        public async Task<IEnumerable<Team>> GetByCoach(string coach)
        {
            return await _teamService.GetByCoach(coach);
        }

        [HttpGet("getby/captain/{captain}")]
        public async Task<IEnumerable<Team>> GetByCaptain(string captain)
        {
            return await _teamService.GetByCaptain(captain);
        }

        [HttpPost("save")]
        public async Task Save([FromBody] Team team)
        {
            await _teamService.Save(team);
        }

        [HttpPut("update/{id}")]
        public async Task Update(int id, [FromBody] Team team)
        {
            await _teamService.Update(id, team);
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete(int id)
        {
            await _teamService.Delete(id);
        }
    }
}