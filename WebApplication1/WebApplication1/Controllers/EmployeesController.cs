using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
      // EmpCoreDBContext empdb = new EmpCoreDBContext();

        private readonly EmpCoreDBContext _context;
        public EmployeesController(EmpCoreDBContext context)
        {
            _context = context;
        }

        [Route("getAllEmployee")]
        [HttpGet]
        public IEnumerable<Emp> GetAllEmployee()
        {
            try
            {
                  var res = _context.Employees.ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [Route("addEmployee")]
        [HttpPost]
        public ActionResult AddEmployee(Emp emp)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var res = _context.Employees.Add(emp);
                    _context.SaveChanges();
                    return Ok(emp);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Route("getEmpById")]
        [HttpGet]
        public ActionResult GetEmpById(int id)
        {
            try
            {

                var res = _context.Employees.Find(id);
                if (res == null)
                {
                    return BadRequest("No Id");

                }
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("updateEmployee")]
        [HttpPut]
        public ActionResult UpdateEmployee(Emp emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingstudent = _context.Employees.Where(s => s.EmployeeId == emp.EmployeeId).FirstOrDefault<Emp>();
                    if (existingstudent != null)
                    {
                        existingstudent.EmployeeName = emp.EmployeeName;
                        existingstudent.EmployeeSalary = emp.EmployeeSalary;
                        existingstudent.EmployeeAddress = emp.EmployeeAddress;
                        existingstudent.EmployeePhone = emp.EmployeePhone;
                        _context.SaveChanges();
                        return Ok(emp);
                    }
                    return BadRequest("Not Updated successfullly");

                }
                else
                {
                    return BadRequest(ModelState);

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Route("deleteEmployee")]
        [HttpDelete]
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                var res = _context.Employees.Find(id);
                if (res == null)
                {
                    return BadRequest("Id is not available");
                }
                _context.Employees.Remove(res);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
