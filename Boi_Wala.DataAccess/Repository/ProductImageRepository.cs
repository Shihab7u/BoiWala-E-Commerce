using Boi_Wala.DataAccess.Repository.IRepository;
using Boi_Wala.Models;
using BoiWala.DataAccess.Data;
using BoiWala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Boi_Wala.DataAccess.Repository
{
	public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
	{

		private ApplicationDbContext _db;
		public ProductImageRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(ProductImage obj)
		{
			_db.ProductImages.Update(obj);
		}
	}
}
