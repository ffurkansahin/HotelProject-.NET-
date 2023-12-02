using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IAppUserDAL : IGenericDAL<AppUser>
    {
        public List<AppUser> UserListWithWorkLocation();

        public List<AppUser> UsersListWithWorkLocations();
    }
}
