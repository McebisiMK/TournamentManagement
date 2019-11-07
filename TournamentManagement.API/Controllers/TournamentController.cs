using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TournamentManagement.Entities.Models;
using TournamentManagement.IServices_Tournament;

namespace TournamentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet("getall")]
        public async Task<IEnumerable<Tournament>> GetAll()
        {
            return await _tournamentService.GetAll();
        }

        [HttpGet("getby/id/{id}")]
        public async Task<Tournament> GetById(int id)
        {
            return await _tournamentService.GetById(id);
        }

        [HttpGet("getby/name/{name}")]
        public async Task<Tournament> GetByName(string name)
        {
            return await _tournamentService.GetByName(name);
        }

        [HttpGet("betby/date/{startdate}")]
        public async Task<IEnumerable<Tournament>> GetByDate(DateTime startDate)
        {
            return await _tournamentService.GetByDate(startDate);
        }

        [HttpGet("getby/location/{location}")]
        public async Task<IEnumerable<Tournament>> GetByLocation(string location)
        {
            return await _tournamentService.GetByLocation(location);
        }

        [HttpPost("save")]
        public async Task Save([FromBody] Tournament tournament)
        {
            await _tournamentService.Save(tournament);
        }

        [HttpPut("update/{id}")]
        public async Task Update(int id, [FromBody] Tournament tournament)
        {
            await _tournamentService.Update(id, tournament);
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete(int id)
        {
            await _tournamentService.Delete(id);
        }
    }
}
