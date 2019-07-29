using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class UserRepository
    {
        BufferOverflowDB AV = new BufferOverflowDB();

        public List<UserEntity> GetAll()
        {
            List<UserEntity> allusers = (from ue in AV.UserDb select ue).ToList();
            return allusers;
        }
        public UserEntity Get(string email)
        {


            UserEntity getuser = (from ue in AV.UserDb where ue.email == email select ue).FirstOrDefault();
            return getuser;



        }

        public bool Create(UserEntity user)
        {
            try
            {
                AV.UserDb.Add(user);
                AV.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {

                return false;
            }
        }

        public bool Delete(string email)
        {
            try
            {
                UserEntity delete = (from ue in AV.UserDb where ue.email == email select ue).FirstOrDefault();
                AV.UserDb.Remove(delete);
                AV.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}