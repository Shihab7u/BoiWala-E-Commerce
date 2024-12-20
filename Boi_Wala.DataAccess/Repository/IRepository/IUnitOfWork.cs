﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boi_Wala.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository Category{ get; }
		IProductRepository Product { get; }
		ICompanyRepository Company { get; }
        IShoppingCartRepository ShoppingCart { get; }

		IOrderHeaderRepository OrderHeader { get; }
		IOrderDetailRepository OrderDetail { get; }
		IApplicationUserRepository ApplicationUser { get; }
		IProductImageRepository ProductImage { get; }

		void Save();


	}
}
