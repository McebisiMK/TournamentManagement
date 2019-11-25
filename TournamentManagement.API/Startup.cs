using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TournamentManagement.Entities.Models;
using TournamentManagement.IRepository;
using TournamentManagement.IRepository_Registration;
using TournamentManagement.IRepository_Team;
using TournamentManagement.IRepository_Tournament;
using TournamentManagement.IServices_Registration;
using TournamentManagement.IServices_Team;
using TournamentManagement.IServices_Tournament;
using TournamentManagement.Repositories;
using TournamentManagement.Repositories_Registration;
using TournamentManagement.Repositories_Team;
using TournamentManagement.Repositories_Tournament;
using TournamentManagement.Services_Registration;
using TournamentManagement.Services_Team;
using TournamentManagement.Services_Tournament;

namespace TournamentManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            var connectionString = Configuration.GetConnectionString("TournamentManagementDatabase");
            services.AddDbContext<TournamentManagementDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITournamentService, TournamentService>();
            services.AddScoped<ITournamentRepository, TournamentRepository>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            services.AddScoped<IGenericRepository<Team>, GenericRepository<Team>>();
            services.AddScoped<IGenericRepository<Tournament>, GenericRepository<Tournament>>();
            services.AddScoped<IGenericRepository<Registration>, GenericRepository<Registration>>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(options => options
                                    .AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
