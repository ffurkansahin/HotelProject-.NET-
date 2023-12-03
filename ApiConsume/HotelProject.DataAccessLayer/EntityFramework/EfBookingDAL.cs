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
    public class EfBookingDAL : GenericRepository<Booking>, IBookingDAL
    {
        public EfBookingDAL(Context context) : base(context)
        {
        }

        public void BookingStatusChangeApproved(Booking booking)
        {
            var context = new Context();
            var values = context.Bookings?.Where(x => x.BookingID == booking.BookingID).FirstOrDefault();
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void ChangeBookingStatusToApproved(int id)
        {
            var context = new Context();
            var values = context.Bookings?.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void ChangeBookingStatusToCall(int id)
        {
            var context = new Context();
            var value = context.Bookings?.Find(id);
            value.Status = "Müşteri Aranacak";
            context.SaveChanges();
        }

        public void ChangeBookingStatusToCanceled(int id)
        {
            var context = new Context();
            var value = context.Bookings?.Find(id);
            value.Status = "İptal Edildi";
            context.SaveChanges();
        }

        //public void ChangeBookingStatusToApproved(int id)
        //{
        //    var context = new Context();
        //    var values = context.Bookings?.Find(id);
        //    values.Status = "Onaylandı";
        //    context.SaveChanges();

        //}

        public int GetBookingCount()
        {
            var context = new Context();
            return context.Bookings.Count();
        }

        public List<Booking> GetLast6Booking()
        {
            var context = new Context();
            return context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
        }
    }
}
