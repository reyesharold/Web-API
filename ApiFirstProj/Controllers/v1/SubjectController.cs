using ApiFirstProj.DTO;
using ApiFirstProj.Entities;
using ApiFirstProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFirstProj.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectServices _subjectServices;

        public SubjectController(ISubjectServices subjectServices)
        {
            _subjectServices = subjectServices;
        }

        [HttpPost]
        public async Task<ActionResult<SubjectResponse>> CreateStudent(SubjectAddRequest subject)
        {
            var response = await _subjectServices.AddSubjectAsync(subject);

            return CreatedAtAction("GetSubject", new { id = response.Id }, response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectResponse>> GetSubject(Guid id)
        {
            var response = await _subjectServices.GetSubjectViaIdAsync(id);
            if (response == null) { return NotFound(); }

            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectResponse>>> GetSubjects()
        {
            var response = await _subjectServices.GetAllSubjects();

            if (response == null) { NotFound(); }

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            var response = await _subjectServices.DeleteSubjectViaIdAsync(id);

            if (!response) { return UnprocessableEntity(); }

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<Student>> UpdateSubjectDetails(Guid id, SubjectUpdateRequest request)
        {
            var response = await _subjectServices.UpdateSubjectViaIdAsync(id, request);
            if (response == null) { return NotFound(); }

            return Ok(response);
        }
    }
}
