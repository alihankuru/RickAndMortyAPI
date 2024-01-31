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
    public class CharacterManager : ICharacterService
    {
        private readonly ICharacterDal _characterDal;

        public CharacterManager(ICharacterDal characterDal)
        {
            _characterDal = characterDal;
        }

        public void TDelete(Character t)
        {
            _characterDal.Delete(t);
        }

        public Character TGetByID(int id)
        {
            return _characterDal.GetByID(id);
        }

        public List<Character> TGetList()
        {
            return _characterDal.GetList();
        }

        public void TInsert(Character t)
        {
            _characterDal.Insert(t);
        }

        public void TUpdate(Character t)
        {
            _characterDal.Update(t);
        }
    }
}
