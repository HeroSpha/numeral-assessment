﻿using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using Numeral.CoffeeShop.Application.Common.Persistence;
using Numeral.CoffeeShop.EntityFrameworkCore.Persistence;

namespace Numeral.CoffeeShop.EntityFrameworkCore.Common;

public class GenericRepository<TEntity> : IRepository<TEntity>  where TEntity : class
{
    internal readonly CoffeeShopDbContext _context;
    internal readonly DbSet<TEntity> DbSet;

    public GenericRepository(CoffeeShopDbContext context)
    {
        this._context = context;
        this.DbSet = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = DbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public virtual async Task<TEntity> GetByIdAsync(object id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(object id)
    {
        TEntity entityToDelete = await DbSet.FindAsync(id);
        await DeleteAsync(entityToDelete);
    }

    public virtual async Task DeleteAsync(TEntity entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            DbSet.Attach(entityToDelete);
        }
        DbSet.Remove(entityToDelete);
    }

    public virtual async Task UpdateAsync(TEntity entityToUpdate)
    {
        DbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}