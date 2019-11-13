using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TournamentManagement.Entities.Models;
using TournamentManagement.IRepository_Tournament;
using TournamentManagement.Services_Tournament;

namespace TournamentManagement.Tests.Tournaments
{
    [TestFixture]
    class TournamentTests
    {
        [Test]
        public async Task Save_Given_Tournament_With_No_Name_Should_Not_Add_Tournament()
        {
            //----------------------Arrange----------------------
            var tournament = new Tournament("", DateTime.Today, "YYYY");
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);

            //----------------------Act--------------------------
            await tournamentService.Save(tournament);

            //----------------------Assert-----------------------
            await tournamentRepository.DidNotReceive().Save(tournament);
        }

        [Test]
        public async Task Save_Given_Tournament_With_No_Location_Should_Not_Add_Tournament()
        {
            //----------------------Arrange----------------------
            var tournament = new Tournament("XXXX", DateTime.Today, "");
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);

            //----------------------Act--------------------------
            await tournamentService.Save(tournament);

            //----------------------Assert-----------------------
            await tournamentRepository.DidNotReceive().Save(tournament);

        }

        [Test]
        public async Task Save_Given_Tournament_With_Passed_Date_Should_Not_Add_Tournament()
        {
            //----------------------Arrange----------------------
            var tournament = new Tournament("XXXX", DateTime.Today.AddDays(-10), "YYYY");
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);

            //----------------------Act--------------------------
            await tournamentService.Save(tournament);

            //----------------------Assert-----------------------
            await tournamentRepository.DidNotReceive().Save(tournament);

        }

        [Test]
        public async Task Save_Given_Valid_Tournament_Details_Should_Add_Tournament()
        {
            //----------------------Arrange----------------------
            var tournament = new Tournament("XXXX", DateTime.Today.AddDays(+10), "YYYY");
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);
            tournamentRepository.Exist(Arg.Any<Expression<Func<Tournament, bool>>>()).Returns(false);

            //----------------------Act--------------------------
            await tournamentService.Save(tournament);

            //----------------------Assert-----------------------
            await tournamentRepository.Received(1).Save(tournament);

        }

        [Test]
        public async Task GetAll_Given_There_Are_Existing_Tournaments_Should_Get_All_Tournaments()
        {
            //----------------------Arrange----------------------
            var tournaments = new List<Tournament>()
            {
                new Tournament("XXXX", DateTime.Today.AddDays(+10), "YYYY"),
                new Tournament("XXDX", DateTime.Today.AddDays(+15), "YYDY"),
                new Tournament("XFXX", DateTime.Today.AddDays(+20), "YFYY"),
            };
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);
            tournamentRepository.GetAll().Returns(tournaments);

            //----------------------Act--------------------------
            var results = await tournamentService.GetAll();

            //----------------------Assert-----------------------
            results.Should().BeEquivalentTo(tournaments);

        }

        [Test]
        public async Task GetById_Given_Existing_Tournament_Should_Get_Tournament_By_Id()
        {
            //-----------------------Arrange------------------
            var id = 1;
            var tournament = new Tournament("XXXX", DateTime.Today.AddDays(+10), "YYYY");
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);
            tournamentRepository.GetById(id).Returns(tournament);

            //-----------------------Act----------------------
            var results = await tournamentService.GetById(id);

            //-----------------------Assert-------------------
            results.Should().BeEquivalentTo(tournament);
        }

        [Test]
        public async Task GetByName_Given_An_Existing_Tournament_Should_Get_Tournament_By_Name()
        {
            //-----------------------Arrange------------------
            var tournamentName = "XXXX";
            var tournament = new Tournament("XXXX", DateTime.Today.AddDays(+10), "YYYY");
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);
            tournamentRepository.GetByName(tournamentName).Returns(tournament);

            //-----------------------Act----------------------
            var results = await tournamentService.GetByName(tournamentName);

            //-----------------------Assert-------------------
            results.Should().BeEquivalentTo(tournament);
        }

        [Test]
        public async Task GetByLocation_Given_An_Existing_Tournament_Should_Get_Tournament_By_Location()
        {
            //-----------------------Arrange------------------
            var tournamentLocation = "XXXX";
            var tournament = new List<Tournament>()
            {
                new Tournament("XXXX", DateTime.Today.AddDays(+10), "YYYY")
            };
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);
            tournamentRepository.GetByLocation(tournamentLocation).Returns(tournament);

            //-----------------------Act----------------------
            var results = await tournamentService.GetByLocation(tournamentLocation);

            //-----------------------Assert-------------------
            results.Should().BeEquivalentTo(tournament);
        }

        [Test]
        public async Task GetByDate_Given_An_Existing_Tournament_Should_Get_Tournament_By_Date()
        {
            //-----------------------Arrange------------------
            var startDate = DateTime.Today.AddDays(+10);
            var tournament = new List<Tournament>()
            {
                new Tournament("XXXX", DateTime.Today.AddDays(+10), "YYYY")
            };
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);
            tournamentRepository.GetByDate(startDate).Returns(tournament);

            //-----------------------Act----------------------
            var results = await tournamentService.GetByDate(startDate);

            //-----------------------Assert-------------------
            results.Should().BeEquivalentTo(tournament);
        }

        [Test]
        public async Task Update_Given_Tournament_That_Does_Not_Exist_Should_Not_Update_Tournament()
        {
            //-----------------------Arrange-----------------
            var id = 1;
            var updatedTournament = new Tournament("XXXX", DateTime.Today.AddDays(+10), "YYYY");
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);
            tournamentRepository.Exist(Arg.Any<Expression<Func<Tournament, bool>>>()).Returns(false);

            //-----------------------Act---------------------
            await tournamentService.Update(id, updatedTournament);

            //-----------------------Assert------------------
            await tournamentRepository.DidNotReceive().Update(Arg.Any<Tournament>(), updatedTournament);
        }

        [Test]
        public async Task Update_Given_An_Existing_Tournament_Should_Update_Tournament()
        {
            //-----------------------Arrange-----------------
            var id = 1;
            var updatedTournament = new Tournament("XXXX", DateTime.Today.AddDays(+10), "YYYY");
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);
            tournamentRepository.Exist(Arg.Any<Expression<Func<Tournament, bool>>>()).Returns(true);

            //-----------------------Act---------------------
            await tournamentService.Update(id, updatedTournament);

            //-----------------------Assert------------------
            await tournamentRepository.Received(1).Update(Arg.Any<Tournament>(), updatedTournament);
        }

        [Test]
        public async Task Delete_Given_Tournament_That_Does_Not_Exist_Should_Not_Delete_Tournament()
        {
            //-----------------------Arrange-----------------
            var id = 01;
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);
            tournamentRepository.Exist(Arg.Any<Expression<Func<Tournament, bool>>>()).Returns(false);

            //-----------------------Act---------------------
            await tournamentService.Delete(id);

            //-----------------------Assert------------------
            await tournamentRepository.DidNotReceive().Delete(Arg.Any<Tournament>());
        }

        [Test]
        public async Task Delete_Given_An_Existing_Tournament_Should_Delete_Tournament()
        {
            //-----------------------Arrange-----------------
            var id = 01;
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = CreateTournamentService(tournamentRepository);
            tournamentRepository.Exist(Arg.Any<Expression<Func<Tournament, bool>>>()).Returns(true);

            //-----------------------Act---------------------
            await tournamentService.Delete(id);

            //-----------------------Assert------------------
            await tournamentRepository.Received(1).Delete(Arg.Any<Tournament>());
        }

        private TournamentService CreateTournamentService(ITournamentRepository tournamentRepository)
        {
            return new TournamentService(tournamentRepository);
        }
    }
}