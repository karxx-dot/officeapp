using Microsoft.EntityFrameworkCore;
using OfficeApp.DAL.Data;

namespace OfficeApp.DAL.Repositories.Base;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly OfficeDbContext Context;
    protected readonly DbSet<T> DbSet;

    protected BaseRepository(OfficeDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
        => await DbSet.AsNoTracking().ToListAsync();

    public virtual async Task<T?> GetByIdAsync(int id)
        => await DbSet.FindAsync(id);

    public virtual async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity is null) return;
        DbSet.Remove(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task<bool> ExistsAsync(int id)
        => await DbSet.FindAsync(id) is not null;
}
