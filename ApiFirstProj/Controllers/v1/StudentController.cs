using ApiFirstProj.AppDbContext;
using ApiFirstProj.Common;
using ApiFirstProj.DTO;
using ApiFirstProj.Entities;
using ApiFirstProj.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstProj.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponse>> CreateStudent(StudentAddRequest student)
        {
            var response = await _studentServices.AddStudentAsync(student);

            return CreatedAtAction("GetStudent", new { id = response.Id}, response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponse>> GetStudent(Guid id)
        {
            var response = await _studentServices.GetStudentViaIdAsync(id);
            if (response == null) { return NotFound(); }

            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetStudents()
        {
            var response = await _studentServices.GetAllStudents();

            if (response == null) { NotFound(); }

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var response = await _studentServices.DeleteStudentViaIdAsync(id);

            if (!response) { return UnprocessableEntity(); }

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<StudentResponse>> UpdateStudentDetails(Guid id,StudentUpdateRequest request)
        {
            var response = await _studentServices.UpdateStudentViaIdAsync(id,request);
            if (response == null) { return NotFound(); }

            return Ok(response);
        }
    }
}
