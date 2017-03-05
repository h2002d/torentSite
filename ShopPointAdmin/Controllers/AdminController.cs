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

        public ActionResult Index(int? id)
        {
            Category category = Category.GetCategory(id);
            ViewBag.Title = category.CategoryName;
            List<Post> postsList = Post.GetPosts(null, id);
            return View(postsList);
        
        }

        public ActionResult Orders()
        {
            List<Order> order = Order.GetOrder(null);
            ViewBag.Title = "Պատվերներ";
            return View(order);
        }


        [HttpPost]
        public string SaveOrderStatus(int orderId, int statusId)
        {
            try
            {
                Order.SaveOrderStatus(orderId, statusId);
                return string.Format("Հաջողությամբ կատարվել է");
            }
            catch (Exception ex)
            {
                return string.Format("Չի հաջողվել կատարել");
            }
        }
        public ActionResult OrderDetails(int id)
        {
            

            var model = new Status();

            // Create a list of SelectListItems so these can be rendered on the page
            model.States = GetSelectListItems(Status.GetStatuses());
           
            Order order =  Order.GetOrder(id).FirstOrDefault();
            ViewBag.Title="Պատվեր #"+id.ToString();
            ViewBag.Model = order;
            return View(model);
        }

        
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<Status> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.State,
                    Text = element.Name
                });
            }

            return selectList;
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            Post post = Post.GetPosts(id, null).FirstOrDefault();
            return View(post);
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
            catch(Exception ex)
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
