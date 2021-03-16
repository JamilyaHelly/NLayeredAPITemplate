using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class Service<TEnity> : IService<TEnity> where TEnity : class
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<TEnity> _repository;
        public Service(IUnitOfWork unitOfWork, IRepository<TEnity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public  async Task<TEnity> AddAsync(TEnity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public  async Task <IEnumerable<TEnity>> AddRangeAsync(IEnumerable<TEnity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public  async Task<IEnumerable<TEnity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public  async Task<TEnity> GetByIdAsync(int id)
        {
             return await _repository.GetByIdAsync(id);
        }

        public void Remove(TEnity entity)
        {
              _repository.Remove(entity);
            _unitOfWork.Commit();

        }

        public void RemoveRange(IEnumerable<TEnity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<TEnity> SingleoRDefaultAsync(Expression<Func<TEnity, bool>> predicate)
        {
             return await _repository.SingleoRDefaultAsync(predicate);
        }

        public TEnity Update(TEnity entity)
        {
           var entityUpdate =_repository.Update(entity);
              _unitOfWork.Commit();

              return entityUpdate;
        }

        public async  Task<IEnumerable<TEnity>> Where(Expression<Func<TEnity, bool>> predicate)
        {
           return  await _repository.Where(predicate);
        }

      
    }
}