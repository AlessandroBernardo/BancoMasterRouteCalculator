using Domain.Entities;
using Domain.Entities.DTOResults;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        void Delete(Guid id);

        IList<TEntity> Get();

        TEntity GetById(Guid id);

        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
