﻿using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Service.Common.Paging
{
	public static class PagingExtension
	{
		public static async Task<DataCollection<T>> GetPagedAsync<T>( this IQueryable<T> query, int page, int take)
		{
			var originalPages = page;
			page--;
			if (page > 0)
			{
				page = page * take;
			}
			var result = new DataCollection<T>
			{
				Items = await query.Skip(page).Take(page).ToListAsync(),
				TotalItems = query.Count(),
				Page = originalPages

			};
			if (result.TotalItems > 0)
			{
				result.TotalPages = (int)Math.Ceiling((decimal)result.TotalItems / take);
			}
			return result;
		}
	}
}
