using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServicesDAL _servicesDAL;

        public ServiceManager(IServicesDAL servicesDAL)
        {
            _servicesDAL = servicesDAL;
        }

        public void TDelete(Service t)
        {
            _servicesDAL.Delete(t);
        }

        public Service TGetByID(int id)
        {
            return _servicesDAL.GetByID(id);
        }

        public List<Service> TGetList()
        {
            return _servicesDAL.GetList();
        }

        public void TInsert(Service t)
        {
            _servicesDAL.Insert(t);
        }

        public void TUpdate(Service t)
        {
            _servicesDAL.Update(t);
        }
    }
}
