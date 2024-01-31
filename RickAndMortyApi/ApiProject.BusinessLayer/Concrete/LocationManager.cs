using ApiProject.BusinessLayer.Abstract;
using ApiProject.DataAccessLayer.Abstract;
using ApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.BusinessLayer.Concrete
{
    public class LocationManager:ILocationService
    {
        private readonly ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public void TDelete(Location t)
        {
            _locationDal.Delete(t);
        }

        public Location TGetByID(int id)
        {
            return _locationDal.GetByID(id);
        }

        public List<Location> TGetList()
        {
            return _locationDal.GetList();
        }

        public void TInsert(Location t)
        {
            _locationDal.Insert(t);
        }

        public void TUpdate(Location t)
        {
            _locationDal.Update(t);
        }
    }
}
