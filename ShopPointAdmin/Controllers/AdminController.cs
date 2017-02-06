using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopPointAdmin.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            
            List<Post> postsList = Post.GetPosts(null, 2);
            return View(postsList);
        
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Post post)
        {
            try
            {
                // TODO: Add insert logic here
                if (post != null)
                {
                    post.SavePost();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Post.DeletePost(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
