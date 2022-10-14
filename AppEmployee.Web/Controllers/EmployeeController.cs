using AppEmployee.Bll.Services;
using AppEmployee.Dll.Entities;
using AppEmployee.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEmployee.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }
        // GET: EmployeeController
        public ActionResult Index(string searchString)
        {
            ViewBag.search = searchString;
            List<EmployeeViewModel> employees = _mapper.Map<List<Employee>, List<EmployeeViewModel>>(_employeeService.ListEmployees(searchString).Result);
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employee)
        {
            try
            {
                Employee emp = _mapper.Map<Employee>(employee);
                _employeeService.AddEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            EmployeeViewModel empM = _mapper.Map<EmployeeViewModel>(employee);
            if (empM == null)
            {
                return NotFound();
            }

            return View(empM);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,EmployeeViewModel employee)
        {
            Employee emp = _mapper.Map<Employee>(employee);
            if (id != emp.Emp_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
