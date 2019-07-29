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

namespace BL.Services
{
   public class QuestionService
    {
        QuestionRepository ur = new QuestionRepository();
        public List<QuestionDTO> GetAll()
        {
            List<QuestionEntity> allquestions = ur.GetAll();
            List<QuestionDTO> l1 = Mapper.Map<List<QuestionDTO>>(allquestions);
            return l1;
        }
        public QuestionDTO Get(int ID)
        {
            QuestionEntity getquestion = ur.Get(ID);
            QuestionDTO question = Mapper.Map<QuestionDTO>(getquestion);
            return question;
        }



        public bool Create(QuestionDTO user)
        {
            bool b1 = ur.Create(Mapper.Map<QuestionEntity>(user));

            return b1;
        }

        public bool Delete(QuestionDTO ID)
        {
            bool b1 = ur.Delete(Mapper.Map<QuestionEntity>(ID));
            return b1;
        }
        public bool Update (QuestionDTO question)
        {
            bool b1 = ur.Update(Mapper.Map<QuestionEntity>(question));
            return b1;
        }
    }
}
