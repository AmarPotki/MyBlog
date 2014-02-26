using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Core.Infrastructure;
using MyBlog.Core.Model;
using MyBlog.Core.Repository;
using MyBlog.Infrastructure.DataAccess;

namespace MyBlog.MVC.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagController(ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        //
        // GET: /Tag/

        public ActionResult Index()
        {
            return View(_tagRepository.All());
        }

        //
        // GET: /Tag/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    var banner = _tagRepository.ById(id);
        //    if (banner == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(banner);
        //}

        //
        // GET: /Tag/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tag/Create

        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagRepository.Add(tag);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        //
        // GET: /Tag/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var tag = _tagRepository.ById(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // POST: /Tag/Edit/5

        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagRepository.Update(tag);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        //
        // GET: /Tag/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var tag = _tagRepository.ById(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // POST: /Tag/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var tag = _tagRepository.ById(id);
            _tagRepository.Delete(tag);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}