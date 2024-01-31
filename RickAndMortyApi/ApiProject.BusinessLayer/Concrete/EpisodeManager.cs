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
    public class EpisodeManager: IEpisodeService
    {
        private readonly IEpisodeDal _episodeDal;

        public EpisodeManager(IEpisodeDal episodeDal)
        {
            _episodeDal = episodeDal;
        }

        public void TDelete(Episode t)
        {
            _episodeDal.Delete(t);
        }

        public Episode TGetByID(int id)
        {
            return _episodeDal.GetByID(id); 
        }

        public List<Episode> TGetList()
        {
            return _episodeDal.GetList();
        }

        public void TInsert(Episode t)
        {
            _episodeDal.Insert(t);
        }

        public void TUpdate(Episode t)
        {
            _episodeDal.Update(t);
        }
    }
}
