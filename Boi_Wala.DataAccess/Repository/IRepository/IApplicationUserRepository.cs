using Boi_Wala.Models;
using BoiWala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boi_Wala.DataAccess.Repository.IRepository
{
	public interface IApplicationUserRepository : IRepository<ApplicationUser>
	{
		 public void Update(ApplicationUser applicationUser);
	}
}
