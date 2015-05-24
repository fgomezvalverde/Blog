using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogExam.Models;
using PagedList;

namespace BlogExam.Controllers
{
    public class PostsController : Controller
    {
        private BlogExamContext db = new BlogExamContext();

        /// <summary>
        /// Show all the POST, depending of the page
        /// </summary>
        /// <param name="page"></param> ACTUAL PAGE
        /// <param name="pageSize"></param> AMOUNT OF POST FOR PAGE
        /// <returns></returns>
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            pageSize = ConfigParameters.AMOUNT_POST_BY_PAGE;
            List<Post> posts = db.Posts.ToList();
            PagedList<Post> model = new PagedList<Post>(posts, page, pageSize);
            return View(model);
        }

        /// <summary>
        /// Call the details view
        /// </summary>
        /// <param name="id"></param> find the post with the ID value
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        /// <summary>
        /// Call the Create View for POST
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Save the POST instance on the database
        /// </summary>
        /// <param name="post"></param> HAS ALL THE VALUES OF THE POST
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DATE,TITLE,AUTHOR,TAGS,BODY")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        /// <summary>
        /// Call to edit view
        /// </summary>
        /// <param name="id"></param> depending of the ID POST, put the old values
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        /// <summary>
        /// Set the values on the database
        /// </summary>
        /// <param name="post"></param> HAS ALL THE VALUES OF THE NEW POST
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DATE,TITLE,AUTHOR,TAGS,BODY")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
