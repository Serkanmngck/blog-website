﻿using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var context = new Context();
            var values = context.Employees.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var context = new Context();
            context.Add(employee);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if(employee!=null)
            {
                return Ok(employee);
            }

            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Remove(employee);
                context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }
        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var context = new Context();
            var emp = context.Find<Employee>(employee.ID);
            if (emp != null)
            {
                emp.Name = employee.Name;
                context.Update(emp);
                context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

    }
}
