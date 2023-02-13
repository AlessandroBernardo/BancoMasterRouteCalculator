using Domain.Entities;
using Domain.Entities.DTOResults;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IInMemoryBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(Guid id);

        IList<TEntity> Select();

        TEntity Select(Guid id);        
    }
}
