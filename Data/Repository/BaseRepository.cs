using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqlContext _sqlContext;

        public BaseRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }       

        public async void Insert(TEntity obj)
        {
            obj.Id = Guid.NewGuid();
            await _sqlContext.Set<TEntity>().AddAsync(obj);
            await _sqlContext.SaveChangesAsync();
        }

        public async void Update(TEntity obj)
        {
            _sqlContext.Entry(obj).State = EntityState.Modified;
            await _sqlContext.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            _sqlContext.Set<TEntity>().Remove(Select(id));
            await _sqlContext.SaveChangesAsync();
        }

        public IList<TEntity> Select() =>         
            _sqlContext.Set<TEntity>().ToList();


        public TEntity Select(int id) =>
            _sqlContext.Set<TEntity>().Find(id);   

        
    }
}
