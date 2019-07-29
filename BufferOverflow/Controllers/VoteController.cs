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
    public class VoteController : ApiController
    {
        // Post: Vote
        
        VoteService us = new VoteService();
        
       
        [ResponseType(typeof(VoteDTO))]
        [HttpPost]
        public IHttpActionResult GetLVotes(VoteDTO qid)
        {

            var gettingAll = (from odd in us.GetAll()
                          where
qid.userId == odd.userId && qid.answerId == odd.answerId
                          select odd).FirstOrDefault();
            if (gettingAll == null)
            {
               var usr = us.Get(qid.voteId);
                qid.voter = true;
                qid.vote = true;
                us.Create(qid);
                ModelState.Clear();
                var use = us.Get(qid.voteId);
                return CreatedAtRoute("DefaultApi", new { id = qid.voteId }, qid);



            }
            else
            {

                if (gettingAll.voter == true && gettingAll.vote == true)

                {
                    ModelState.AddModelError("", " Invalid Email");
                    return BadRequest("");

                }
                else
                {

                    var voter = (from odd in us.GetAll()
                                 where
       qid.userId == odd.userId && qid.answerId == odd.answerId
                                 select odd).FirstOrDefault();

                    us.Update(voter);
                    var result = CreatedAtRoute("DefaultApi", new { id = qid.voteId }, qid);

                    return result;

                }
            }

        }
        [ResponseType(typeof(VoteDTO))]
        [Route("api/DVotes")]
        [HttpPost]
        public HttpResponseMessage GetDVotes(VoteDTO qid)
        {

            var gettingAll = (from odd in us.GetAll()
                          where
qid.userId == odd.userId && qid.answerId == odd.answerId
                          select odd).FirstOrDefault();
            if (gettingAll == null)
            {

                var usr = us.Get(qid.voteId);
                qid.voter = true;
                qid.vote = false;
                us.Create(qid);
                ModelState.Clear();
                var use = us.Get(qid.voteId);
                return Request.CreateResponse(HttpStatusCode.OK, new {isDisliked=true });
                //return CreatedAtRoute("DefaultApi", new { id = qid.voteId }, qid);

            }
            else
            {

                if (gettingAll.voter == true && gettingAll.vote == false)

                {
                    ModelState.AddModelError("", " Invalid Email");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { isDisliked = false });


                }
                else
                {


                    var voter = (from odd in us.GetAll()
                                 where
       qid.userId == odd.userId && qid.answerId == odd.answerId
                                 select odd).FirstOrDefault();
                    
                    us.Update(voter);
                    return Request.CreateResponse(HttpStatusCode.OK, new { isDisliked = true });
                    //return result;

                }
            }


        }
    }
}