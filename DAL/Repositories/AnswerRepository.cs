using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class AnswerRepository
    {

        BufferOverflowDB AV = new BufferOverflowDB();

        public List<AnswerEntity> GetAll()
        {
            List<AnswerEntity> allanswers = (from ue in AV.AnswerDb select ue).ToList();
            return allanswers;
        }
        public AnswerEntity Get(int answer)
        {


            AnswerEntity getanswer = (from ue in AV.AnswerDb where ue.AnswerId == answer select ue).FirstOrDefault();
            return getanswer;



        }
        public bool Update(AnswerEntity answer)
        {
            var ans = AV.AnswerDb.SingleOrDefault(v => v.AnswerId == answer.AnswerId);
            ans.answers = answer.answers;
           

            try
            {
                AV.AnswerDb.Attach(ans);
                AV.Entry(ans).State = EntityState.Modified;
                AV.SaveChanges();

            }
            catch (Exception ex)
            {

                return false;
            }
            return true;

        }

        public bool Create(AnswerEntity answer)
        {
            try
            {
               
                AV.AnswerDb.Add(answer);
                AV.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return false;

            }
        }






        public bool IncrementVotes(int aId)
        {
            var votes = AV.AnswerDb.SingleOrDefault(a => a.AnswerId == aId);
            votes.NumberOfUpVotes = votes.NumberOfUpVotes + 1;

            try
            {
                AV.AnswerDb.Attach(votes);
                AV.Entry(votes).State = EntityState.Modified;
                AV.SaveChanges();

            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }
        public bool IncrementVotess(int aId)
        {
            var votes = AV.AnswerDb.SingleOrDefault(a => a.AnswerId == aId);
            votes.NumberOfUpVotes = votes.NumberOfUpVotes + 1;
            votes.NumberOfDownVotes = votes.NumberOfDownVotes - 1;
            try
            {
                AV.AnswerDb.Attach(votes);
                AV.Entry(votes).State = EntityState.Modified;
                AV.SaveChanges();

            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }
    
    public bool DecrementVotes(int aId)
    {
        var votes = AV.AnswerDb.SingleOrDefault(a => a.AnswerId == aId);
        votes.NumberOfDownVotes = votes.NumberOfDownVotes + 1;

        try
        {
            AV.AnswerDb.Attach(votes);
            AV.Entry(votes).State = EntityState.Modified;
            AV.SaveChanges();

        }
        catch (Exception ex)
        {

                return false;
            }
            return true;
        }
        public bool DecrementVotess(int aId)
        {
            var votes = AV.AnswerDb.SingleOrDefault(a => a.AnswerId == aId);
            votes.NumberOfDownVotes = votes.NumberOfDownVotes + 1;
            votes.NumberOfUpVotes = votes.NumberOfUpVotes - 1;
            try
            {
                AV.AnswerDb.Attach(votes);
                AV.Entry(votes).State = EntityState.Modified;
                AV.SaveChanges();

            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }





        public bool Delete(AnswerEntity ID)
        {
            try
            {
                AnswerEntity delete = (from ue in AV.AnswerDb where ue.AnswerId == ID.AnswerId select ue).FirstOrDefault();
                AV.AnswerDb.Remove(delete);
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
