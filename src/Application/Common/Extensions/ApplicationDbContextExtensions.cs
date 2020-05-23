using System;
using System.Linq;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Exceptions;
using GlassZebra.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace GlassZebra.Application.Common.Extensions
{
	public static class ApplicationDbContextExtensions
	{
		public static TEntity FindByClientId<TEntity>(this IQueryable<TEntity> dbSet, Guid clientId) 
			where TEntity : class, IHaveClientId
		{
			var entity = dbSet.FirstOrDefault(e => e.ClientId == clientId);

			if(entity == null)
				throw new NotFoundException(nameof(TEntity), clientId);

			return entity;
		}

		public static async Task<TEntity> FindByClientIdAsync<TEntity>(this IQueryable<TEntity> dbSet, Guid clientId)
			where TEntity : class, IHaveClientId
		{
			var entity = await dbSet.FirstOrDefaultAsync(e => e.ClientId == clientId);

			if (entity == null)
				throw new NotFoundException(nameof(TEntity), clientId);

			return entity;
		}
	}
}
