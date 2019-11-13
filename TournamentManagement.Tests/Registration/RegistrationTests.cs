using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using TournamentManagement.Entities.Models;
using TournamentManagement.IRepository_Registration;
using TournamentManagement.IRepository_Team;
using TournamentManagement.IRepository_Tournament;
using TournamentManagement.Services_Registration;

namespace TournamentManagement.Tests_Registration
{
    [TestFixture]
    public class RegistrationTests
    {
        [Test]
        public async Task Register_Given_New_Registration_With_Both_Tournament_And_Team_That_Does_Not_Exist_Should_Not_Register_Team()
        {
            //----------------------Arrange--------------------------------
            var registration = new Registration(3, 3, 6000);
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var teamRepository = Substitute.For<ITeamRepository>();
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var registrationService = CreateRegistrationService(tournamentRepository, teamRepository, registrationRepository);
            tournamentRepository.Exist(Arg.Any<Expression<Func<Tournament, bool>>>()).Returns(false);
            teamRepository.Exist(Arg.Any<Expression<Func<Team, bool>>>()).Returns(false);
            registrationRepository.Exist(Arg.Any<Expression<Func<Registration, bool>>>()).Returns(false);


            //----------------------Act------------------------------------
            await registrationService.Register(registration);

            //----------------------Assert---------------------------------
            await registrationRepository.DidNotReceive().Register(registration);

        }

        [Test]
        public async Task Register_Given_New_Registration_With_Tournament_That_Does_Not_Exist_Should_Not_Register_Team()
        {
            //----------------------Arrange----------------------------
            var registration = new Registration(6, 1, 500);
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var teamRepository = Substitute.For<ITeamRepository>();
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var registrationService = CreateRegistrationService(tournamentRepository, teamRepository, registrationRepository);
            tournamentRepository.Exist(Arg.Any<Expression<Func<Tournament, bool>>>()).Returns(false);
            teamRepository.Exist(Arg.Any<Expression<Func<Team, bool>>>()).Returns(true);
            registrationRepository.Exist(Arg.Any<Expression<Func<Registration, bool>>>()).Returns(false);

            //----------------------Act--------------------------------
            await registrationService.Register(registration);

            //----------------------Assert-----------------------------
            await registrationRepository.DidNotReceive().Register(registration);

        }

        [Test]
        public async Task Register_Given_New_Registration_With_Team_That_Does_Not_Exist_Should_Not_Register_Team()
        {
            //----------------------Arrange--------------------------------
            var registration = new Registration(2, 3, 6000);
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var teamRepository = Substitute.For<ITeamRepository>();
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var registrationService = CreateRegistrationService(tournamentRepository, teamRepository, registrationRepository);
            tournamentRepository.Exist(Arg.Any<Expression<Func<Tournament, bool>>>()).Returns(true);
            teamRepository.Exist(Arg.Any<Expression<Func<Team, bool>>>()).Returns(false);
            registrationRepository.Exist(Arg.Any<Expression<Func<Registration, bool>>>()).Returns(false);

            //----------------------Act------------------------------------
            await registrationService.Register(registration);

            //----------------------Assert---------------------------------
            await registrationRepository.DidNotReceive().Register(registration);

        }

        [Test]
        public async Task Register_Given_Valid_New_Registration_With_Both_Existing_Tournament_And_Team_Should_Register_Team()
        {
            //----------------------Arrange----------------------------
            var registration = new Registration(1, 1, 5000);
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var teamRepository = Substitute.For<ITeamRepository>();
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var registrationService = CreateRegistrationService(tournamentRepository, teamRepository, registrationRepository);
            tournamentRepository.Exist(Arg.Any<Expression<Func<Tournament, bool>>>()).Returns(true);
            teamRepository.Exist(Arg.Any<Expression<Func<Team, bool>>>()).Returns(true);
            registrationRepository.Exist(Arg.Any<Expression<Func<Registration, bool>>>()).Returns(false);

            //----------------------Act--------------------------------
            await registrationService.Register(registration);

            //----------------------Assert-----------------------------
            await registrationRepository.Received(1).Register(registration);

        }

        [Test]
        public async Task Update_Given_Registration_Details_That_Does_Not_Exist_Should_Not_Update_Registration()
        {
            //----------------------Arrange----------------------------
            var id = 1;
            var registration = new Registration(1, 1, 4000);
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var teamRepository = Substitute.For<ITeamRepository>();
            var registrationService = CreateRegistrationService(tournamentRepository, teamRepository, registrationRepository);
            registrationRepository.Exist(Arg.Any<Expression<Func<Registration, bool>>>()).Returns(false);

            //----------------------Act--------------------------------
            await registrationService.Update(id, registration);

            //----------------------Assert-----------------------------
            await registrationRepository.DidNotReceive().Update(Arg.Any<Registration>(), registration);

        }

        [Test]
        public async Task Update_Given_An_Existing_Registration_Should_Update_Registration()
        {
            //----------------------Arrange----------------------------
            var id = 2;
            var registration = new Registration(2, 2, 4000);
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var teamRepository = Substitute.For<ITeamRepository>();
            var registrationService = CreateRegistrationService(tournamentRepository, teamRepository, registrationRepository);
            registrationRepository.Exist(Arg.Any<Expression<Func<Registration, bool>>>()).Returns(true);

            //----------------------Act--------------------------------
            await registrationService.Update(id, registration);

            //----------------------Assert-----------------------------
            await registrationRepository.Received(1).Update(Arg.Any<Registration>(), registration);

        }

        [Test]
        public async Task Delete_Given_Registration_Details_That_Does_Not_Exist_Should_Not_Delete_Registration()
        {
            //----------------------Arrange----------------------------
            var id = 1;
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var teamRepository = Substitute.For<ITeamRepository>();
            var registrationService = CreateRegistrationService(tournamentRepository, teamRepository, registrationRepository);
            registrationRepository.Exist(Arg.Any<Expression<Func<Registration, bool>>>()).Returns(false);

            //----------------------Act--------------------------------
            await registrationService.Delete(id);

            //----------------------Assert-----------------------------
            await registrationRepository.DidNotReceive().Delete(Arg.Any<Registration>());

        }

        [Test]
        public async Task Delete_Given_An_Existing_Registration_Should_Delete_Registration()
        {
            //----------------------Arrange----------------------------
            var id = 1;
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var teamRepository = Substitute.For<ITeamRepository>();
            var registrationService = CreateRegistrationService(tournamentRepository, teamRepository, registrationRepository);
            registrationRepository.Exist(Arg.Any<Expression<Func<Registration, bool>>>()).Returns(true);

            //----------------------Act--------------------------------
            await registrationService.Delete(id);

            //----------------------Assert-----------------------------
            await registrationRepository.Received(1).Delete(Arg.Any<Registration>());

        }

        private static RegistrationService CreateRegistrationService(ITournamentRepository tournamentRepository, ITeamRepository teamRepository, IRegistrationRepository registrationRepository)
        {
            return new RegistrationService(tournamentRepository, teamRepository, registrationRepository);
        }
    }
}