using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Common.Collection
{
	public class DataCollection<T>
	{
		public bool HasItems
		{ 
			get{ return this.Items != null && this.Items.Any(); }
		}
		public int Page { get; set; }
		public  IEnumerable<T> Items { get; set; }
		public int TotalPages { get; set; }
		public int TotalItems { get; set; }
	}
}
