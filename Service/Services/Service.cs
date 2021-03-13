using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {


      public readonly IUnitOfWork _unitOfWork;
      private readonly IRepository <TEntity> _repository;
      public Service(IUnitOfWork unitOfWork , IRepository<TEntity> repository)
      {
          _repository=repository;
          _unitOfWork=unitOfWork;
      }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> SingleoRDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.SingleoRDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity entityUpdate=_repository.Update(entity);
            _unitOfWork.Commit();
            return entityUpdate;
        }

        public async  Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }

        Task IService<TEntity>.AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task IService<TEntity>.AddRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}