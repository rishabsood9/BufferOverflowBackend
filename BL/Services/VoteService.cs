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
   public class VoteService
    {
        VoteRepository ur = new VoteRepository();
        AnswerRepository ar = new AnswerRepository();
        AnswerService asa = new AnswerService(); 
        public List<VoteDTO> GetAll()
        {
            List<VoteEntity> allvotes = ur.GetAll();
            List<VoteDTO> l1 = Mapper.Map<List<VoteDTO>>(allvotes);
            return l1;
        }
        public VoteDTO Get(int ID)
        {
            VoteEntity getvote = ur.Get(ID);
            VoteDTO vote = Mapper.Map<VoteDTO>(getvote);
            return vote;
        }

        

        public bool Create(VoteDTO user)
        {
            bool b1 = ur.Create(Mapper.Map<VoteEntity>(user));
            
            if (b1)
            {


                
                if (user.vote == true )
                {
                    ar.IncrementVotes(user.answerId);
                }
                else  {
                    ar.DecrementVotes(user.answerId);

                        }
            }

            return b1;
        }

        public bool Delete(int ID)
        {
            bool b1 = ur.Delete(ID);
            return b1;
        }

        public bool Update(VoteDTO user)
        { 
           
            bool b1 = ur.Update(Mapper.Map<VoteEntity>(user));
            if (b1)
            {



                if (user.vote != true)
                {
                    ar.IncrementVotess(user.answerId);
                }
                else
                {
                    ar.DecrementVotess(user.answerId);

                }
            }

            return b1;
        }
    }
}
