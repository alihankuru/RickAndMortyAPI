using ApiProject.DataAccessLayer.Abstract;
using ApiProject.DataAccessLayer.Concrete;
using ApiProject.DataAccessLayer.Repositories;
using ApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.DataAccessLayer.EntityFramework
{
    public class EfCharacterDal:GenericRepository<Character>,ICharacterDal
    {
        public EfCharacterDal(Context context): base(context) 
        {
            
        }
    }
}
