using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(int? id)
        {
            Category category = Category.GetCategory(id);
            ViewBag.Title = category.CategoryName;
            List<Post> postsList = Post.GetPosts(null, id);
            return View(postsList);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            Post post = Post.GetPosts(id,null).FirstOrDefault();
            ViewBag.Post = post;

            ViewBag.Result = TempData["Result"];
            TempData["Result"] = null;
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(Order model)
        {
             try{
                model.SaveOrder();

              TempData["Result"] = "Ձեր պատվերը հաջողությամբ կատարվել է:";
                return RedirectToAction("Details", new
                {
                    id = model.ItemId
                    
                });
                
             }
            catch(Exception e )
             {
                 TempData["Result"] = "Ձեր պատվերը չի կատարվել տեխնիկական խոտանի պատճառով";
                  return RedirectToAction("Details", new
                  {
                      id = model.ItemId

                  });
             }
        }
    }
}
