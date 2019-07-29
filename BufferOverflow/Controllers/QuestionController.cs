using BL.Service;
using BL.Services;
using Shared;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using static System.Net.WebRequestMethods;

namespace BufferOverflow.Controllers
{


    public class QuestionController : ApiController
    {
        QuestionService us = new QuestionService();
        AnswerService asd= new AnswerService();
        QuestionDTO udto = new QuestionDTO();


        //POST: api/Question

        [HttpPost]

        [ResponseType(typeof(QuestionDTO))]
        public IHttpActionResult PostQuestion(AddQuestionModel model)
        {

            QuestionDTO question = new QuestionDTO();
            question.Date = model.Date;
            question.Description = model.Description;
            question.Title = model.Title;
            question.tags = model.tags;
            question.username = model.username;
            if (model.image == null && model.name == null)
            {
                question.QuestionImage = "NoImage.png";
            }
            else
            {
                question.QuestionImage = saveImage(model.image, model.name);
            }
            us.Create(question);
           
            ModelState.Clear();
            var use = us.Get(question.questionId);

            return CreatedAtRoute("DefaultApi", new { id = question.questionId }, question);

           



        }

        public string saveImage(string image, string name)
        {
            string imageName = null;
            imageName = new string(Path.GetFileNameWithoutExtension(name).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(name);

            byte[] bytes = Convert.FromBase64String(image);
            using (Image actualImage = Image.FromStream(new MemoryStream(bytes)))
            {
                //actualImage.Save("output.jpg", ImageFormat.Jpeg); 
                actualImage.Save(System.Web.HttpContext.Current.Server.MapPath("~/QuestionImages/" + imageName));// Or Png
            }

            return imageName;
        }
        public string getImage(string imageName)
        {

            string path = HttpContext.Current.Server.MapPath("~/QuestionImages/") + imageName;
            string base64String;
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }

        }


        [HttpGet]
        [Route("api/editQuestions")]
        [ResponseType(typeof(QuestionDTO))]
        public IEnumerable<QuestionDTO> editQuestions(int questionId)

        {





            List<QuestionDTO> li = new List<QuestionDTO>();
            li = (from odd in us.GetAll() where odd.questionId==questionId select odd).ToList();


            return li;






        }
        [HttpPost]
        [Route("api/editedQuestions")]
        [ResponseType(typeof(QuestionDTO))]
        public IHttpActionResult editedQuestions(QuestionDTO qid)
        {





            us.Update(qid);
            ModelState.Clear();
            var use = us.Get(qid.questionId);
            return CreatedAtRoute("DefaultApi", new { id = qid.questionId }, qid);







        }

        //POST: api/Question

        [HttpGet]
        [Route("api/getQuestions")]
        [ResponseType(typeof(QuestionDTO))]
        public IEnumerable<QuestionDTO> GetAllQuestions()
        {





            List<QuestionDTO> li = new List<QuestionDTO>();
            li = (from odd in us.GetAll() orderby odd.Date descending select odd).ToList();
            for(int i=0;i<li.Count();i++)
            {
                li[i].QuestionImage = getImage(li[i].QuestionImage);
            }

            return li;
            





        }

       
        [HttpPost]
        [Route("api/questionDelete")]
        [ResponseType(typeof(QuestionDTO))]
        public IHttpActionResult questionDelete(QuestionDTO obj)
        {

            
            us.Delete(obj);
            ModelState.Clear();
            var use = us.Get(obj.questionId);
            return CreatedAtRoute("DefaultApi", new { id = obj.questionId }, obj.questionId);





        }



        [Route("api/getYourQuestions")]
        [ResponseType(typeof(QuestionDTO))]
        [HttpGet]
        public IEnumerable<QuestionDTO> getYourQuestions( string username)
      {





            List<QuestionDTO> li = new List<QuestionDTO>();
            li = (from odd in us.GetAll() where username==odd.username  select odd).ToList();


            return li;






        }

    }
}


       