using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactCrudApplication.Models;

namespace ReactCrudApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContxt _studentDbContxt;

        public StudentController(StudentDbContxt studentDbContxt)
        {
                _studentDbContxt = studentDbContxt;
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContxt.Students.ToListAsync();
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudents(Student objStudent)
        {
            _studentDbContxt.Students.Add(objStudent);
            await _studentDbContxt.SaveChangesAsync();
            return objStudent;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<Student> UpdateStudent(Student objStudent)
        {
            _studentDbContxt.Entry(objStudent).State = EntityState.Modified;
            await _studentDbContxt.SaveChangesAsync();
            return objStudent;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public bool DeleteStudent(int id)
        {
            bool a = false;
            var student = _studentDbContxt.Students.Find(id);
            if (student != null)
            {
                a = true;
                _studentDbContxt.Entry(student).State = EntityState.Deleted;
                _studentDbContxt.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;
        }
    }

}
