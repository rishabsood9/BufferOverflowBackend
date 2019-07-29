using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Shared.DTO;
using DAL.Repositories;
using BL.Helper;
using AutoMapper;

namespace BL.Service
{
    public class UserService
    {
        UserRepository ur = new UserRepository();
        public List<UserDTO> GetAll()
        {
            List<UserEntity> allusers = ur.GetAll();
            List<UserDTO> l1 = Mapper.Map<List<UserDTO>>(allusers);
            return l1;
        }
        public UserDTO Get(string email)
        {
            UserEntity getuser = ur.Get(email);
            UserDTO user = Mapper.Map<UserDTO>(getuser);
            return user;
        }



        public bool Create(UserDTO user)
        {
            bool b1 = ur.Create(Mapper.Map<UserEntity>(user));

            return b1;
        }

        public bool Delete(string email)
        {
            bool b1 = ur.Delete(email);
            return b1;
        }






    }
}
