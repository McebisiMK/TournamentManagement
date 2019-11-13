using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TournamentManagement.Entities.Models;
using TournamentManagement.IRepository_Team;
using TournamentManagement.Services_Team;

namespace TournamentManagement.Tests.Teams
{
    [TestFixture]
    class TeamTests
    {
        [Test]
        public async Task Save_Given_New_Team_With_No_Name_Should_Not_Add_Team()
        {
            //-----------------------Arrange-----------------
            var team = new Team("", "Jack", "Jill");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            //-----------------------Act---------------------
            await teamService.Save(team);

            //-----------------------Assert------------------
            await teamRepository.DidNotReceive().Save(team);
        }

        [Test]
        public async Task Save_Given_New_Team_With_No_Captain_Should_Not_Add_Team()
        {
            //-----------------------Arrange-----------------
            var team = new Team("Jack", "Jill", "");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            //-----------------------Act---------------------
            await teamService.Save(team);

            //-----------------------Assert------------------
            await teamRepository.DidNotReceive().Save(team);
        }

        [Test]
        public async Task Save_Given_New_Team_With_No_Coach_Should_Not_Add_Team()
        {
            //-----------------------Arrange-----------------
            var team = new Team("Jack", "", "Jill");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            //-----------------------Act---------------------
            await teamService.Save(team);

            //-----------------------Assert------------------
            await teamRepository.DidNotReceive().Save(team);

        }

        [Test]
        public async Task Save_Given_New_Team_With_Valid_Details_Should_Save_Team_To_DB()
        {
            //-----------------------Arrange------------------
            var team = new Team("Jack", "Jill", "JJ");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            teamRepository.Exist(Arg.Any<Expression<Func<Team, bool>>>()).Returns(false);

            //-----------------------Act----------------------
            await teamService.Save(team);

            //-----------------------Assert-------------------
            await teamRepository.Received(1).Save(team);
        }

        [Test]
        public async Task GetAll_Given_There_Are_Existing_Teams_Should_Return_All_Teams()
        {
            //-----------------------Arrange-----------------
            var teams = new List<Team>()
            {
                new Team("Jack", "Jill", "JJ"),
                new Team("Jane", "Jade", "JJ"),
                new Team("Jup", "Jup", "JJ")
            };
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            teamRepository.GetAll().Returns(teams);

            //-----------------------Act---------------------
            var results = await teamService.GetAll();

            //-----------------------Assert------------------
            results.Should().BeEquivalentTo(teams);
        }

        [Test]
        public async Task GetById_Given_An_Existing_Team_Should_Search_By_Id()
        {
            //-----------------------Arrange------------------
            var id = 1;
            var team = new Team("Jack", "Jill", "JJ");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            teamRepository.GetById(id).Returns(team);

            //-----------------------Act----------------------
            var results = await teamService.GetById(id);

            //-----------------------Assert-------------------
            results.Should().BeEquivalentTo(team);
        }

        [Test]
        public async Task GetByName_Given_An_Existing_Team_Should_Search_By_Name()
        {
            //-----------------------Arrange------------------
            var name = "Jack";
            var team = new Team("Jack", "Jill", "JJ");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            teamRepository.GetByName(name).Returns(team);

            //-----------------------Act----------------------
            var results = await teamService.GetByName(name);

            //-----------------------Assert-------------------
            results.Should().BeEquivalentTo(team);
        }

        [Test]
        public async Task GetByCoach_Given_An_Existing_Team_Should_Search_By_Coach()
        {
            //-----------------------Arrange------------------
            var coach = "Jack";
            var team = new List<Team>()
            {
                new Team("Jack", "Jill", "JJ")
            };
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            teamRepository.GetByCoach(coach).Returns(team);

            //-----------------------Act----------------------
            var results = await teamService.GetByCoach(coach);

            //-----------------------Assert-------------------
            results.Should().BeEquivalentTo(team);
        }

        [Test]
        public async Task GetByCaptain_Given_An_Existing_Team_Should_Search_By_Captain()
        {
            //-----------------------Arrange-----------------
            var captain = "Jack";
            var team = new List<Team>()
            {
                new Team("Jack", "Jill", "JJ")
            };
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            teamRepository.GetByCaptain(captain).Returns(team);

            //-----------------------Act---------------------
            var results = await teamService.GetByCaptain(captain);

            //-----------------------Assert------------------
            results.Should().BeEquivalentTo(team);
        }

        [Test]
        public async Task Update_Given_Team_That_Does_Not_Exist_Should_Not_Update_Team()
        {
            //-----------------------Arrange-----------------
            var id = 1;
            var updatedTeam = new Team("Jack", "will", "JJ");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            teamRepository.Exist(Arg.Any<Expression<Func<Team, bool>>>()).Returns(false);

            //-----------------------Act---------------------
            await teamService.Update(id, updatedTeam);

            //-----------------------Assert------------------
            await teamRepository.DidNotReceive().Update(Arg.Any<Team>(), updatedTeam);
        }

        [Test]
        public async Task Update_Given_An_Existing_Team_Should_Be_Able_To_Update_Team()
        {
            //-----------------------Arrange-----------------
            var id = 1;
            var updatedTeam = new Team("Jack", "will", "JJ");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            teamRepository.Exist(Arg.Any<Expression<Func<Team, bool>>>()).Returns(true);

            //-----------------------Act---------------------
            await teamService.Update(id, updatedTeam);

            //-----------------------Assert------------------
            await teamRepository.Received(1).Update(Arg.Any<Team>(), updatedTeam);
        }

        [Test]
        public async Task Delete_Given_Team_That_Does_Not_Exist_Should_Not_Delete_Team()
        {
            //-----------------------Arrange-----------------
            var id = 1;
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            teamRepository.Exist(Arg.Any<Expression<Func<Team, bool>>>()).Returns(false);

            //-----------------------Act---------------------
            await teamService.Delete(id);

            //-----------------------Assert------------------
            await teamRepository.DidNotReceive().Delete(Arg.Any<Team>());
        }

        [Test]
        public async Task Delete_Given_An_Existing_Team_Should_Be_Able_To_Delete()
        {
            //-----------------------Arrange-----------------
            var id = 1;
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = CreateTeamService(teamRepository);

            teamRepository.Exist(Arg.Any<Expression<Func<Team, bool>>>()).Returns(true);

            //-----------------------Act---------------------
            await teamService.Delete(id);

            //-----------------------Assert------------------
            await teamRepository.Received(1).Delete(Arg.Any<Team>());
        }

        private TeamService CreateTeamService(ITeamRepository teamRepository)
        {
            return new TeamService(teamRepository);
        }
    }
}