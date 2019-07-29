using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
   public class VoteRepository
    {
       BufferOverflowDB AV = new BufferOverflowDB();

        public List<VoteEntity> GetAll()
        {
            List<VoteEntity> allvotes = (from ue in AV.VoteDb select ue).ToList();
            return allvotes;
        }
        public VoteEntity Get(int voteid)
        {


            VoteEntity getvote = (from ue in AV.VoteDb where ue.voteId == voteid select ue).FirstOrDefault();
            return getvote;



        }
        public bool Create(VoteEntity user)
        {
            try
            {
                AV.VoteDb.Add(user);
                AV.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int ID)
        {
            try
            {
                VoteEntity delete = (from ue in AV.VoteDb where ue.voteId == ID select ue).FirstOrDefault();
                AV.VoteDb.Remove(delete);
                AV.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(VoteEntity voter)
        {
            var vote = AV.VoteDb.SingleOrDefault(v => v.voteId == voter.voteId);
            vote.vote = !vote.vote;
            
                try
                {
                    AV.VoteDb.Attach(vote);
                    AV.Entry(vote).State = EntityState.Modified;
                    AV.SaveChanges();
                    
                }
                catch (Exception ex)
                {
                    
                  return false;
                }
            return true;
            
        }



    }
}
