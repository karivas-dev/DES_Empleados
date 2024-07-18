using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DES_Empleados.Models;

namespace DES_Empleados.Controllers
{
    public class ProjectAssignmentsController : Controller
    {
        private readonly EmployeesDBContext _context;

        public ProjectAssignmentsController(EmployeesDBContext context)
        {
            _context = context;
        }

        // GET: ProjectAssignments
        public async Task<IActionResult> Index()
        {
            var employeesDBContext = _context.ProjectAssignments.Include(p => p.Employee).Include(p => p.Project);
            return View(await employeesDBContext.ToListAsync());
        }

        // GET: ProjectAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAssignment = await _context.ProjectAssignments
                .Include(p => p.Employee)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectAssignment == null)
            {
                return NotFound();
            }

            return View(projectAssignment);
        }

        // GET: ProjectAssignments/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Lastname");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Description");
            return View();
        }

        // POST: ProjectAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,ProjectId,AssignmentDate,Rol")] ProjectAssignment projectAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Lastname", projectAssignment.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Description", projectAssignment.ProjectId);
            return View(projectAssignment);
        }

        // GET: ProjectAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAssignment = await _context.ProjectAssignments.FindAsync(id);
            if (projectAssignment == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Lastname", projectAssignment.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Description", projectAssignment.ProjectId);
            return View(projectAssignment);
        }

        // POST: ProjectAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,ProjectId,AssignmentDate,Rol")] ProjectAssignment projectAssignment)
        {
            if (id != projectAssignment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectAssignmentExists(projectAssignment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Lastname", projectAssignment.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Description", projectAssignment.ProjectId);
            return View(projectAssignment);
        }

        // GET: ProjectAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectAssignment = await _context.ProjectAssignments
                .Include(p => p.Employee)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectAssignment == null)
            {
                return NotFound();
            }

            return View(projectAssignment);
        }

        // POST: ProjectAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectAssignment = await _context.ProjectAssignments.FindAsync(id);
            if (projectAssignment != null)
            {
                _context.ProjectAssignments.Remove(projectAssignment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectAssignmentExists(int id)
        {
            return _context.ProjectAssignments.Any(e => e.Id == id);
        }
    }
}
