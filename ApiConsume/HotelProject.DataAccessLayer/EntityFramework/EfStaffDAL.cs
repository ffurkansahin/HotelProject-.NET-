using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDAL : GenericRepository<Staff>, IStaffDAL
    {
        public EfStaffDAL(Context context) : base(context)
        {
        }

        public List<Staff> GetLast4Staff()
        {
            var context = new Context();
            return context.Staffs.OrderByDescending(x => x.StaffID).Take(4).ToList();
        }

        public int GetStaffCount()
        {
            var context = new Context();
            return context.Staffs.Count();
        }
    }
}
