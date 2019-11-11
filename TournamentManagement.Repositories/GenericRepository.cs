using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TournamentManagement.Entities.Models;
using TournamentManagement.IRepository;

namespace TournamentManagement.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TournamentManagementDBContext DbContext;
        private readonly DbSet<TEntity> DbSet;

        public GenericRepository(TournamentManagementDBContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = DbSet;

            return query;
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public bool Exist(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Any(expression);
        }

        public async Task Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void Update(TEntity oldEntity, TEntity newEntity)
        {
            DbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
