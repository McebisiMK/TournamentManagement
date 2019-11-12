using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TournamentManagement.Entities.Models;

namespace TournamentManagement.IRepository_Registration
{
    public interface IRegistrationRepository
    {
        Task<IEnumerable<Registration>> GetAll();
        Task<Registration> GetById(int id);
        Task Register(Registration registration);
        Task Update(Registration oldRegistration, Registration newRegistration);
        Task Delete(Registration registration);
        bool Exist(Expression<Func<Registration, bool>> expression);
    }
}