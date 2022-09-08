using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Helpers;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskWebAPI.Data;
using TaskWebAPI.Models;

namespace TaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly StudentContext _context;

        public SearchController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Search
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            return await _context.Student.ToListAsync();
        }
       // GET: api/Search/FirstName=shivam
       [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent(string id)
        {
            //var student = await _context.Student.FindAsync(id);
            var student = from FirstName in _context.Student select FirstName;
            string key = id.Split('=')[0];
            string value = id.Split('=')[1];
            if (key == "FirstName")
            {
                student = student.Where(s => s.FirstName.StartsWith(value));
                return await student.ToListAsync();
            }
            return await student.ToListAsync();
        }
        //api/person/byName?firstName=a&lastName=b

        //[HttpPost]
        //public async Task<ActionResult<Student>> PostStudent(int id,string firstname,string lastname,string gender)
        //{
        //    var student = await _context.Student.FindAsync(id);

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return CreatedAtAction("GetStudent", new { id = student.Id, firstName = student.FirstName, lastName = student.LastName ,gender=student.Gender}, student);
        //}
        //[HttpGet("{search}")]
        //public async Task<ActionResult<IEnumerable<Student>>> GetStudent(string firstName, string lastName, string gender)
        //{
        //    try
        //    {
        //        var result = await _context.Student(firstName, lastName, gender);
        //        if(result.Any())
        //            {
        //            return Ok(result);
        //        }
        //        return NotFound();
        //    }
        //    catch(Exception)
        //    {
        //        return StatusCode(StatusCode.Status500error)
        //    }
        //}
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Student>>> Poststudent(object fill)
            {
            //dynamic data = Serializer.Deserialize(Json, typeof(object));

            var student = JsonSerializer.Deserialize<Student>(fill.ToString());

            string str = student.FirstName;
            string str1 = student.LastName;
            int str2 = student.Gender;
            var std = from FirstName in _context.Student select FirstName;
            if (!String.IsNullOrEmpty(str))
            {
                std = from stud in _context.Student
                      where stud.FirstName.Contains(str)
                            && stud.LastName.Contains(str1)
                            && stud.Gender.ToString().Contains(str2.ToString())
                      select stud;
                return await std.ToListAsync();
            }
            return await std.ToListAsync();
            //student = await _context.Student.FindAsync(str, str1, str)
            //string str = student.FirstName;
            Console.WriteLine(str);
           // return Ok(student);
        }

        //[HttpPost]
        //public string TestJsonInput1([FromBody] string input)
        //{
        //    return input;
    }
  
}
