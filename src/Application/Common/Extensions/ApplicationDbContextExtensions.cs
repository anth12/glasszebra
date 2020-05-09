using System;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Extensions
{
	public static class ApplicationDbContextExtensions
	{
		public static TEntity FindByClientId<TEntity>(this DbSet<TEntity> dbSet, Guid clientId) 
			where TEntity : class, IHaveClientId
		{
			var entity = dbSet.FirstOrDefault(e => e.ClientId == clientId);

			if(entity == null)
				throw new NotFoundException(nameof(TEntity), clientId);

			return entity;
		}

		public static async Task<TEntity> FindByClientIdAsync<TEntity>(this DbSet<TEntity> dbSet, Guid clientId)
			where TEntity : class, IHaveClientId
		{
			var entity = await dbSet.FirstOrDefaultAsync(e => e.ClientId == clientId);

			if (entity == null)
				throw new NotFoundException(nameof(TEntity), clientId);

			return entity;
		}
	}
}
