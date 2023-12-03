using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDAL : IGenericDAL<Booking>
    {
        void BookingStatusChangeApproved(Booking booking);
        //void BookingStatusChangeApproved2(int id);
        int GetBookingCount();
        List<Booking> GetLast6Booking();
        void ChangeBookingStatusToApproved(int id);
        void ChangeBookingStatusToCanceled(int id);
        void ChangeBookingStatusToCall(int id);

    }
}
