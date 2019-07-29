using BL.Service;
using Shared.DTO;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.IO;
using System.Drawing;
using System.Web;

namespace BufferOverflow.Controllers
{


    public class UserController : ApiController
    {
        UserService us = new UserService();
        UserDTO udto = new UserDTO();

        //POST: api/User

        [HttpPost]
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult PostUser(AddUserModel model)
        {

            UserDTO user = model.user;
            user.ProfileImage = saveImage(model.image, model.name);


            var usr = us.Get(user.email);

            if (usr == null)
            {
                us.Create(user);
                ModelState.Clear();
                var use = us.Get(user.email);
                if (use == null)
                {
                    ModelState.AddModelError("", " Invalid Email");
                    return CreatedAtRoute("DefaultApi", new { id = udto.email }, user);

                }
                else
                {
                    ModelState.AddModelError("", " YOU ARE REGISTERED NOW, CONGRATULATIONS");
                    return CreatedAtRoute("DefaultApi", new { id = udto.email }, user);


                }

            }

            else
            {

                return BadRequest("");
            }
        }
        [HttpGet]
        [Route("api/user")]
        [ResponseType(typeof(UserDTO))]
        public UserDTO getUser(string email)

        {





            UserDTO user = new UserDTO();
           
            user = (from odd in us.GetAll() where odd.email == email select odd).FirstOrDefault();
            user.ProfileImage = getImage(user.ProfileImage);

            return user;






        }


        //POST: api/Login
        [Route("api/Login")]
        [HttpPost]
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult Login(UserDTO user)
        {

            var usr = us.Get(user.email);

            if (usr == null)
            {
                return BadRequest(" Username or Password is Wrong");
            }
            else if (usr.Password != user.Password)
            {

                return BadRequest("wrong password");

            }

            else
            {
                return Ok(usr);




            }



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
                actualImage.Save(System.Web.HttpContext.Current.Server.MapPath("~/Images/" + imageName));// Or Png
            }

            return imageName;
        }


        public string getImage(string imageName)
        {

            string path = HttpContext.Current.Server.MapPath("~/Images/") + imageName;
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



    }















}
