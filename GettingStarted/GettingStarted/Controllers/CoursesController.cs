using GettingStarted.Data;
using GettingStarted.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStarted.Controllers
{
    public class CoursesController : Controller
    {
        private readonly DataContext _context;

        public CoursesController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Section of Course Model
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult CourseList()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDetails(int id)
        {
            var course = _context.Courses.Where(x => x.Id == id).FirstOrDefault();
            return View(course);
        }

        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            var course = _context.Courses.Where(x => x.Id == id).FirstOrDefault();
            return View(course);
        }

        [HttpGet]
        public IActionResult DeleteCourse(int id)
        {
            var course = _context.Courses.Where(x => x.Id == id).FirstOrDefault();
            return View(course);
        }

        /// <summary>
        /// Post Section of Course Model
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateCourse(Course data)
        {
            _context.Courses.Add(data);
            _context.SaveChanges();
            return RedirectToAction("CourseList");
        }

        [HttpPost]
        public IActionResult EditCourse(Course data)
        {
            _context.Courses.Update(data);
            _context.SaveChanges();
            return RedirectToAction("CourseList");
        }

        [HttpPost]
        public IActionResult DeleteCourse(Course data)
        {
            _context.Courses.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("CourseList");
        }
    }
}
