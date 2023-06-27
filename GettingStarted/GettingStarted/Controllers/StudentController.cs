using GettingStarted.Data;
using GettingStarted.DTOs;
using GettingStarted.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStarted.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentController : Controller
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: StudentController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.Include(x => x.Enrollment).ThenInclude(y => y.Course)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: StudentController/Create
        public IActionResult Create()
        {
            var courses = _context.Courses.Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();

            CreateStudentViewModel vm = new CreateStudentViewModel();
            vm.Courses = courses;
            return View(vm);
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentViewModel model)
        {
            var student = new Student
            {
                Name = model.Name,
                Enrolled = model.Enrolled
            };

            var seletedCourse = model.Courses.Where(x => x.Selected).Select(y => y.Value).ToList();
            foreach (var item in seletedCourse)
            {
                student.Enrollment.Add(new StudentCourse()
                {
                    CourseId = Convert.ToInt32(item)
                });
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            //if (ModelState.IsValid)
            //{
            //    _context.Add(student);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            
            return RedirectToAction("Index");
        }

        // GET: StudentController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.Include(x => x.Enrollment).Where(y => y.Id == id).FirstOrDefaultAsync();
            
            if (student == null)
            {
                return NotFound();
            }

            var selectedIds = student.Enrollment.Select(x => x.CourseId).ToList();
            var items = _context.Courses.Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString(),
                Selected = selectedIds.Contains(x.Id)
            }).ToList();

            CreateStudentViewModel data = new CreateStudentViewModel();
            data.Name = student.Name;
            data.Enrolled = student.Enrolled;
            data.Courses = items;

            return View(data);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Enrolled")] Student student)
        //{
        //    if (id != student.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(student);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch(DbUpdateConcurrencyException)
        //        {
        //            if (!StudentExists(student.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(student);
        //}

        public IActionResult Edit(CreateStudentViewModel viewModel)
        {
            var student = _context.Students.Find(viewModel.Id);
            student.Name = viewModel.Name;
            student.Enrolled = viewModel.Enrolled;

            var studentById = _context.Students.Include(x => x.Enrollment).FirstOrDefault(y => y.Id == viewModel.Id);
            var existingIds = studentById.Enrollment.Select(x => x.CourseId).ToList();
            var selectedIds = viewModel.Courses.Where(x => x.Selected).Select(y => y.Value).Select(int.Parse).ToList();
            var toAdd = selectedIds.Except(existingIds).ToList();
            var toRemove = existingIds.Except(selectedIds).ToList();

            student.Enrollment = student.Enrollment.Where(x => !toRemove.Contains(x.CourseId)).ToList();
            foreach (var item in toAdd)
            {
                student.Enrollment.Add(new StudentCourse()
                {
                    CourseId = item
                });
            }

            _context.Students.Update(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: StudentController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(x=> x.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(x => x.Id == id);
        }
    }
}
