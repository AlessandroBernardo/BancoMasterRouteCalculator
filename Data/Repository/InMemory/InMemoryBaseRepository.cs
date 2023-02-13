using Data.Context;
using Domain.Entities;
using Domain.Entities.DTOResults;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Data.Repository.Querys.RouteQuerys;

namespace Data.Repository
{
    public class InMemoryBaseRepository<TEntity> : IInMemoryBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ContextInMemory _inMemoryContext;

        public InMemoryBaseRepository(ContextInMemory inMemoryContext)
        {
            _inMemoryContext = inMemoryContext;
        }

        public virtual void Insert(TEntity obj)
        {      
            
            obj.Id = Guid.NewGuid();
            _inMemoryContext.Set<TEntity>().Add(obj);
            _inMemoryContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _inMemoryContext.Entry(obj).State = EntityState.Modified;
            _inMemoryContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _inMemoryContext.Set<TEntity>().Remove(Select(id));
            _inMemoryContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _inMemoryContext.Set<TEntity>().ToList();


        public TEntity Select(Guid id) =>
            _inMemoryContext.Set<TEntity>().Find(id);




    }
}
