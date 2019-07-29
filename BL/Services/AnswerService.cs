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
    public class AnswerService
    {
        AnswerRepository ur = new AnswerRepository();
        QuestionRepository qr = new QuestionRepository();
        public List<AnswerDTO> GetAll()
        {
            List<AnswerEntity> allanswers = ur.GetAll();
            List<AnswerDTO> l1 = Mapper.Map<List<AnswerDTO>>(allanswers);
            return l1;
        }
        public AnswerDTO Get(int ID)
        {
            AnswerEntity getanswer = ur.Get(ID);
            AnswerDTO answer = Mapper.Map<AnswerDTO>(getanswer);
            return answer;
        }



        public bool Create(AnswerDTO user)
        {

            try
            {
                bool b1 = ur.Create(Mapper.Map<AnswerEntity>(user));
                if (b1)
                {
                    qr.IncrementAnswers(user.QuestionId);
                }

                return b1;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
        public bool Update(AnswerDTO question)
        {
            bool b1 = ur.Update(Mapper.Map<AnswerEntity>(question));
            return b1;
        }

        public bool Delete(AnswerDTO ID)
        {
            bool b1 = ur.Delete(Mapper.Map<AnswerEntity>(ID));
            if (b1)
            {
                qr.DecrementAnswers(ID.QuestionId);

            }
            return b1;
        }

    }

    
}
    
