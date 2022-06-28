using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using onlineStore.Application.IRepositories;
using onlineStore.Application.Paging;
using onlineStore.Core.Entities;
using onlineStore.Infrastructure.ApplicationContext;

namespace onlineStore.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
{
    public GenericRepository(EFContext dbContext)
    {
        this._db = dbContext;
        this._table = dbContext.Set<TEntity>();
    }

    private DbSet<TEntity> _table;

    private EFContext _db;
    
    public async Task AddAsync(TEntity item)
    {
        this._table.AddAsync(item);
        this.SaveAsync();
    }

    public async Task UpdateAsync(TEntity item)
    {
        this._table.Update(item);
        this.SaveAsync();
    }

    public async Task DeleteAsync(TEntity item)
    {
        this._table.Remove(item);
        this.SaveAsync();
    }

    public async Task<TEntity> GetOneAsync(int id)
    {
        return await this._table.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<TEntity> GetOneAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query =  this._table.Where(entity => entity.Id == id);
        foreach (var property in includeProperties)
        {
            query = query.Include(property);
        }

        return await query.FirstOrDefaultAsync(entity => entity.Id == id);
    }
    
    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = this._table.Where(predicate);
        foreach (var property in includeProperties)
        {
            query = query.Include(property);
        }

        return await query.ToListAsync<TEntity>();
    }

    public async Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters)
    {
        var items = this._table.AsNoTracking()
            .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
            .Take(pageParameters.PageSize);
        var pagedList = new PagedList<TEntity>(items, pageParameters, await items.CountAsync());
        return pagedList;
    }

    public async Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var items = this._table.AsNoTracking()
            .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
            .Take(pageParameters.PageSize);
        foreach (var property in includeProperties)
        {
            items = items.Include(property);
        }
        var pagedList = new PagedList<TEntity>(items, pageParameters, await items.CountAsync());
        return pagedList;
    }

    public async Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var items = this._table.AsNoTracking()
            .Where(predicate)
            .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
            .Take(pageParameters.PageSize); ;
        foreach (var property in includeProperties)
        {
            items = items.Include(property);
        }
        var pagedList = new PagedList<TEntity>(items, pageParameters, await items.CountAsync());
        return pagedList;
    }

    public async Task SaveAsync()
    {
        this._db.SaveChangesAsync();
    }
}