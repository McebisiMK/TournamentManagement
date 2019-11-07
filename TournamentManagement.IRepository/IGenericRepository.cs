using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManagement.IRepository
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression);
        Task Add(TEntity entity);
        void Update(TEntity oldEntity, TEntity newEntity);
        void Delete(TEntity entity);
        Task SaveAsync();
        bool Exist(Expression<Func<TEntity, bool>> expression);
    }
}
