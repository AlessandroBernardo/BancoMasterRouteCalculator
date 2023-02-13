using Domain.Entities;
using Domain.Entities.DTOResults;
using Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity 
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IInMemoryBaseRepository<TEntity> _inMemoryBaseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository, IInMemoryBaseRepository<TEntity> inMemoryBaseRepository)
        {
            _baseRepository = baseRepository;
            _inMemoryBaseRepository = inMemoryBaseRepository;
        }  

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            try
            {
                Validate(obj, Activator.CreateInstance<TValidator>());
                _baseRepository.Insert(obj);
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                   
            }          
        
        }

        public void Delete(Guid id) => _baseRepository.Delete(id);

        public IList<TEntity> Get() => _baseRepository.Select();

        public TEntity GetById(Guid id) => _baseRepository.Select(id);

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        }    


    }
}
