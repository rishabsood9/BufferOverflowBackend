using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
   public class QuestionRepository
    {


        BufferOverflowDB AV = new BufferOverflowDB();

        public List<QuestionEntity> GetAll()
        {
            List<QuestionEntity> allquestions = (from ue in AV.QuestionDb select ue).ToList();
            return allquestions;
        }
        public QuestionEntity Get(int ID)
        {


            QuestionEntity getquestion = (from ue in AV.QuestionDb where ue.questionId == ID select ue).FirstOrDefault();
            return getquestion;



        }
        public bool IncrementAnswers(int qId)
        {
            var ques = AV.QuestionDb.SingleOrDefault(q => q.questionId == qId);
            ques.NumberOfAnswers = ques.NumberOfAnswers + 1;

            try
            {
                AV.QuestionDb.Attach(ques);
                AV.Entry(ques).State = EntityState.Modified;
                AV.SaveChanges();

            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }
        public bool DecrementAnswers(int qId)
        {
            var ques = AV.QuestionDb.SingleOrDefault(q => q.questionId == qId);
            ques.NumberOfAnswers = ques.NumberOfAnswers - 1;

            try
            {
                AV.QuestionDb.Attach(ques);
                AV.Entry(ques).State = EntityState.Modified;
                AV.SaveChanges();

            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public bool Create(QuestionEntity question)
        {
            try
            {
                question.NumberOfAnswers = 0;
                AV.QuestionDb.Add(question);
                AV.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(QuestionEntity ID)
        {
            try
            {
                QuestionEntity delete = (from ue in AV.QuestionDb where ue.questionId == ID.questionId select ue).FirstOrDefault();
                AV.QuestionDb.Remove(delete);
                AV.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Update(QuestionEntity question)
        {
            var ques = AV.QuestionDb.SingleOrDefault(v => v.questionId == question.questionId);
            ques.Title=question.Title;
            ques.Description = question.Description;
            ques.tags = question.tags;

            try
            {
                AV.QuestionDb.Attach(ques);
                AV.Entry(ques).State = EntityState.Modified;
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
