using ApiFirstProj.DTO;
using ApiFirstProj.Entities;
using ApiFirstProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectController : ControllerBase
    {
        private readonly IStudentSubjectServices _studentSubjectServices;
        public StudentSubjectController(IStudentSubjectServices studentSubjectServices)
        {
            _studentSubjectServices = studentSubjectServices;
        }

        [HttpPost]
        public async Task<ActionResult<StudentSubjectResponse>> CreateStudent(StudentSubjectAddRequest request)
        {
            var response = await _studentSubjectServices.AssignSubjectToStudentAsync(request);

            return CreatedAtAction("GetStudentSubject", new { studentId = response.StudentId, subjectId = response.SubjectId }, response);
        }
        [HttpGet("{studentId}/{subjectId}")]
        public async Task<ActionResult<StudentSubjectResponse>> GetStudentSubject(Guid studentId, Guid subjectId)
        {
            var response = await _studentSubjectServices.GetStudentSubjectViaCompKeytAsync(studentId, subjectId);
            if (response == null) { return NotFound(); }

            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentSubjectResponse>>> GetStudentSubjects()
        {
            var response = await _studentSubjectServices.GetAllStudentSubjectAsync();

            if (response == null) { NotFound(); }

            return Ok(response);
        }
        [HttpDelete("{studentId}/{subjectId}")]
        public async Task<IActionResult> DeleteStudentSubject(Guid studentId, Guid subjectId)
        {
            var response = await _studentSubjectServices.DeleteStudentSubjectViaIdAsync(studentId, subjectId);

            if (!response) { return UnprocessableEntity(); }

            return NoContent();
        }
        [HttpPatch("{studentId}/{subjectId}")]
        public async Task<ActionResult<StudentSubjectResponse>> UpdateStudentSubject(Guid studentId, Guid subjectId, StudentSubjectUpdateRequest request)
        {
            var response = await _studentSubjectServices.UpdateStudentSubejctViaCompKeyAsync(studentId,subjectId, request);
            if (response == null) { return NotFound(); }

            return Ok(response);
        }
    }
}
