using BL.Service;
using BL.Services;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BufferOverflow.Controllers
{
    public class AnswerController : ApiController
    {
        AnswerService ase=new AnswerService();
        QuestionDTO qdto = new QuestionDTO();
        QuestionService qs = new QuestionService();
        AnswerDTO adto = new AnswerDTO();

        [HttpPost]

        [ResponseType(typeof(AnswerDTO))]
        public IHttpActionResult postAnswer(AnswerDTO aid)
        {
                var usr = ase.Get(aid.AnswerId);

            ase.Create(aid);

            ModelState.Clear();
            var use = ase.Get(aid.AnswerId);
            return CreatedAtRoute("DefaultApi", new { id = aid.AnswerId }, aid);
        }

        [HttpGet]
        [Route("api/getAnswers")]
        [ResponseType(typeof(AnswerDTO))]
        public IEnumerable<AnswerDTO> GetAllAnswers(int QuestionId)
        {
            
            List<AnswerDTO> li = new List<AnswerDTO>();
            li = (from odd in ase.GetAll() where odd.QuestionId==QuestionId select odd).ToList();
             string a = (from o in qs.GetAll() where o.questionId==QuestionId select o.Title).ToString();
             
            var list = (li.OrderByDescending(odd => odd.NumberOfUpVotes).ThenByDescending(odd => odd.Date)).ToList();
            return list;

        }
        
        [Route("api/getYourAnswers")]
        [ResponseType(typeof(AnswerDTO))]
        [HttpGet]
        public IEnumerable<AnswerDTO> getYourAnswers(string username)
        {





            List<AnswerDTO> li = new List<AnswerDTO>();
            li = (from odd in ase.GetAll() where username == odd.useremail  select odd).ToList();


            return li;






        }
        [HttpGet]
        [Route("api/editAnswers")]
        [ResponseType(typeof(AnswerDTO))]
        public IEnumerable<AnswerDTO> editQuestions(int AnswerId)
        {





            List<AnswerDTO> li = new List<AnswerDTO>();
            li = (from odd in ase.GetAll() where odd.AnswerId == AnswerId select odd).ToList();


            return li;






        }
        [HttpPost]
        [Route("api/editedAnswers")]
        [ResponseType(typeof(AnswerDTO))]
        public IHttpActionResult editedAnswers(AnswerDTO qid)
        {





            ase.Update(qid);
            ModelState.Clear();
            var use = ase.Get(qid.AnswerId);
            return CreatedAtRoute("DefaultApi", new { id = qid.AnswerId }, qid);







        }
        [HttpPost]
        [Route("api/answerdelete")]
        [ResponseType(typeof(AnswerDTO))]
        public IHttpActionResult answerDelete(AnswerDTO obj)
        {

            
            ase.Delete(obj);
            ModelState.Clear();
            var use = ase.Get(obj.AnswerId);
            return CreatedAtRoute("DefaultApi", new { id = obj.AnswerId }, obj.AnswerId);





        }


    }
}